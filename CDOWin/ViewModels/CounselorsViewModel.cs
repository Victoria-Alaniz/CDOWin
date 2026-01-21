using CDO.Core.DTOs;
using CDO.Core.ErrorHandling;
using CDO.Core.Interfaces;
using CDO.Core.Models;
using CDOWin.Data;
using CDOWin.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Dispatching;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CDOWin.ViewModels;

public partial class CounselorsViewModel : ObservableObject {

    // =========================
    // Services / Dependencies
    // =========================
    private readonly ICounselorService _service;
    private readonly DataCoordinator _dataCoordinator;
    private readonly CounselorSelectionService _selecitonService;
    private readonly DispatcherQueue _dispatcher;

    // =========================
    // Private Backing Fields
    // =========================
    private IReadOnlyList<Counselor> _allCounselors = [];

    // =========================
    // Public Property / State
    // =========================

    [ObservableProperty]
    public partial ObservableCollection<Counselor> Filtered { get; private set; } = [];

    [ObservableProperty]
    public partial Counselor? Selected { get; set; }

    [ObservableProperty]
    public partial string SearchQuery { get; set; } = string.Empty;

    public CounselorsViewModel(DataCoordinator dataCoordinator, ICounselorService service, CounselorSelectionService selectionService) {
        _service = service;
        _dataCoordinator = dataCoordinator;

        _selecitonService = selectionService;
        _dispatcher = DispatcherQueue.GetForCurrentThread();

        _selecitonService.CounselorSelectionRequested += OnRequestSelectedCounselorChange;

    }

    // =========================
    // Property Change Methods
    // =========================
    partial void OnSearchQueryChanged(string value) {
        if (_dispatcher.HasThreadAccess)
            ApplyFilter();
        else
            _dispatcher.TryEnqueue(ApplyFilter);
    }

    private void OnRequestSelectedCounselorChange(int counselorId) {
        if (Selected != null && Selected.Id == counselorId) return;
        SearchQuery = string.Empty;
        ApplyFilter();
        _ = ReloadCounselorAsync(counselorId);
    }

    // =========================
    // Public Methods
    // =========================
    public List<Counselor> All() => _allCounselors.ToList();

    public List<Counselor> GetCounselors() {
        if (_allCounselors.Count == 0)
            LoadCounselorsAsync().GetAwaiter().GetResult();

        return _allCounselors.ToList();
    }

    // =========================
    // CRUD Methods
    // =========================
    public async Task LoadCounselorsAsync() {
        var counselors = await _dataCoordinator.GetCounselorsAsync();
        if (counselors == null) return;

        var snapshot = counselors.OrderBy(o => o.Name).ToList().AsReadOnly();
        _allCounselors = snapshot;

        _dispatcher.TryEnqueue(() => {
            ApplyFilter();
        });
    }

    public async Task ReloadCounselorAsync(int id) {
        var counselor = await _service.GetCounselorAsync(id);
        if (counselor == null) return;

        var updated = _allCounselors
            .Select(c => c.Id == id ? counselor : c)
            .ToList()
            .AsReadOnly();

        _allCounselors = updated;

        _dispatcher.TryEnqueue(() => {
            var index = Filtered
            .Select((c, i) => new { c, i })
            .FirstOrDefault(x => x.c.Id == id)?.i;

            if (index != null)
                Filtered[index.Value] = counselor;

            Selected = counselor;
        });
    }

    public async Task<Result<Counselor>> UpdateCounselorAsync(UpdateCounselorDTO update) {
        if (Selected == null) return Result<Counselor>.Fail(new AppError(ErrorKind.Validation, "Counselor not selected.", null));

        var result = await _service.UpdateCounselorAsync(Selected.Id, update);
        if (!result.IsSuccess) return result;

        // TODO: Mark data as stale in DataCoordinator to fetch new data on next update

        await ReloadCounselorAsync(Selected.Id);
        return result;
    }

    // =========================
    // Utility / Filtering
    // =========================

    private void ApplyFilter() {
        int? previousSelection = Selected?.Id;

        if (string.IsNullOrWhiteSpace(SearchQuery)) {
            Filtered = new ObservableCollection<Counselor>(_allCounselors);
            ReSelect(previousSelection);
            return;
        }

        var query = SearchQuery.Trim().ToLower();
        var result = _allCounselors.Where(c =>
        (c.Name ?? "").Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
        (c.SecretaryName ?? "").Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
        (c.Email ?? "").Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
        (c.SecretaryEmail ?? "").Contains(query, StringComparison.CurrentCultureIgnoreCase)
        );

        Filtered = new ObservableCollection<Counselor>(result);
        ReSelect(previousSelection);
    }

    private void ReSelect(int? id) {
        if (id == null) return;
        if (Filtered.FirstOrDefault(c => c.Id == id) is Counselor selected)
            Selected = selected;
    }
}