using CDOWin.Extensions;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;

namespace CDOWin.Views.Clients.Dialogs;

public sealed partial class UpdateNotes : Page {

    // =========================
    // Dependencies
    // =========================
    public ClientUpdateViewModel ViewModel;

    // =========================
    // Constructor
    // =========================
    public UpdateNotes(ClientUpdateViewModel viewModel) {
        ViewModel = viewModel;
        InitializeComponent();
    }

    // =========================
    // Property Change Methods
    // =========================
    private void LabeledMultiLinePair_TextChanged(object sender, TextChangedEventArgs e) {
        if (sender is not TextBox textbox)
            return;

        var text = textbox.Text.NormalizeString();

        if (string.IsNullOrWhiteSpace(text))
            return;

        var notes = BuildNotes(text);
        ViewModel.UpdatedClient.ClientNotes = notes;
    }

    // =========================
    // Utility Methods
    // =========================
    private string BuildNotes(string note) {
        var date = DateTime.Now;
        var end = "++++++++++++++++++++++++";
        var newNote = $"{date.ToString()}\n\n{note}\n\n{end}\n\n";
        return newNote + ViewModel.OriginalClient.ClientNotes;
    }
}
