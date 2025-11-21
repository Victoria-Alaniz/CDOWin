using CDOWin.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace CDOWin.Views;

public sealed partial class Documents : Page, INotifyPropertyChanged {
    public ObservableCollection<string> Files { get; private set; } = [];

    public event PropertyChangedEventHandler PropertyChanged;

    public ClientsViewModel ViewModel { get; private set; }

    public Documents() {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) {
        ViewModel = (ClientsViewModel)e.Parameter;
        DataContext = ViewModel;

        // Subscribe to changes
        ViewModel.PropertyChanged += ViewModel_PropertyChanged;

        LoadFiles();
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e) {
        if (ViewModel != null) {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }
    }

    private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(ViewModel.SelectedClient)) {
            LoadFiles();
        }
    }

    public void LoadFiles() {
        var path = ViewModel.SelectedClient?.documentsFolderPath;

        if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path)) {
            Files.Clear();
            return;
        }

        Files.Clear();

        foreach (var file in Directory.GetFiles(path)) {
            Files.Add(Path.GetFileName(file));
        }
    }
}
