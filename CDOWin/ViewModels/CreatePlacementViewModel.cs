using CDO.Core.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace CDOWin.ViewModels;

public partial class CreatePlacementViewModel(IPlacementService service) : ObservableObject {

    // =========================
    // Dependencies
    // =========================
    private readonly IPlacementService _service = service;


    [ObservableProperty]
    public partial int? PlacementNumber { get; set; }

    [ObservableProperty]
    public partial string? EmployerID { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanSave))]
    public partial int? ClientID { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanSave))]
    public partial int? CounselorID { get; set; }

    [ObservableProperty]
    public partial string? PoNumber { get; set; }

    [ObservableProperty]
    public partial string? Supervisor { get; set; }

    [ObservableProperty]
    public partial string? SupervisorEmail { get; set; }

    [ObservableProperty]
    public partial string? SupervisorPhone { get; set; }

    [ObservableProperty]
    public partial string? Position { get; set; }

    [ObservableProperty]
    public partial string? Salary { get; set; }

    [ObservableProperty]
    public partial float? DaysOnJob { get; set; }

    [ObservableProperty]
    public partial string? ClientName { get; set; }

    [ObservableProperty]
    public partial string? CounselorName { get; set; }

    [ObservableProperty]
    public partial bool? Active { get; set; }

    [ObservableProperty]
    public partial string? Website { get; set; }

    [ObservableProperty]
    public partial string? DescriptionOfDuties { get; set; }

    [ObservableProperty]
    public partial string? NumbersOfHoursWorking { get; set; }

    [ObservableProperty]
    public partial string? FirstFiveDays1 { get; set; }

    [ObservableProperty]
    public partial string? FirstFiveDays2 { get; set; }

    [ObservableProperty]
    public partial string? FirstFiveDays3 { get; set; }

    [ObservableProperty]
    public partial string? FirstFiveDays4 { get; set; }

    [ObservableProperty]
    public partial string? FirstFiveDays5 { get; set; }

    [ObservableProperty]
    public partial string? DescriptionOfWorkSchedule { get; set; }

    [ObservableProperty]
    public partial string? HourlyOrMonthlyWages { get; set; }

    [ObservableProperty]
    public partial DateTime? HireDate { get; set; }

    [ObservableProperty]
    public partial DateTime? EndDate { get; set; }

    // =========================
    // Input Validation
    // =========================
    public bool CanSave => CanSaveMethod();

    public bool CanSaveMethod() {


        return true;
    }

    // =========================
    // CRUD Methods
    // =========================
}
