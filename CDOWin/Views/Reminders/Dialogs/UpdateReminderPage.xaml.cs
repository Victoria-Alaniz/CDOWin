using CDOWin.Controls;
using CDOWin.Extensions;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Diagnostics;

namespace CDOWin.Views.Reminders.Dialogs;

public sealed partial class UpdateReminderPage : Page {
    public ReminderUpdateViewModel ViewModel;

    public UpdateReminderPage(ReminderUpdateViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = viewModel.Original;
        InitializeComponent();
        SetupDatePicker();
    }

    private void SetupDatePicker() {
        Debug.WriteLine($"Local Date: {ViewModel.Original.localDate}");
        Debug.WriteLine($"Full Date: {ViewModel.Original.date}");

        if (ViewModel.Original.date is DateTime date) {
            DatePicker.Date = date;
        }
    }

    private void LabeledTextBox_TextChangedForwarded(object sender, TextChangedEventArgs e) {

    }
}
