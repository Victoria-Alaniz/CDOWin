using CDOWin.Extensions;
using CDOWin.Services;
using CDOWin.ViewModels;
using CDOWin.Views.Clients.Dialogs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace CDOWin.Views.Clients.Inspectors;

public sealed partial class Notes : Page {

    // =========================
    // ViewModel
    // =========================
    public ClientsViewModel ViewModel { get; private set; } = AppServices.ClientsViewModel!;

    // =========================
    // Constructor
    // =========================
    public Notes() {
        InitializeComponent();
    }

    // =========================
    // Click Handlers
    // =========================
    private void EditButton_Click(object sender, RoutedEventArgs e) {
        NotesBox.IsReadOnly = false;
        SaveButton.Visibility = Visibility.Visible;
        NewButton.IsEnabled = false;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        SaveButton.Visibility = Visibility.Collapsed;
        NewButton.IsEnabled = true;
        NotesBox.IsReadOnly = true;
        var updateVM = new ClientUpdateViewModel(ViewModel.Selected);
        updateVM.UpdatedClient.ClientNotes = NotesBox.Text.NormalizeString();
        _ = ViewModel.UpdateClientAsync(updateVM.UpdatedClient);
    }

    private async void SplitButton_Click(SplitButton sender, SplitButtonClickEventArgs args) {
        if (ViewModel.Selected == null || sender is null) return;
        var updateVM = new ClientUpdateViewModel(ViewModel.Selected);

        ContentDialog dialog = new() {
            XamlRoot = this.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            PrimaryButtonText = "Add to Notes",
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Title = "Add New Note",
            Content = new UpdateNotes(updateVM)
        };

        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
            _ = ViewModel.UpdateClientAsync(updateVM.UpdatedClient);
    }
}
