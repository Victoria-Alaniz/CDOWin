using CDOWin.Extensions;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;

namespace CDOWin.Views.Clients.Dialogs;

public sealed partial class CreateReminder : Page {

    // =========================
    // Dependencies
    // =========================
    private readonly CreateReminderViewModel ViewModel;

    // =========================
    // Constructor
    // =========================
    public CreateReminder(CreateReminderViewModel viewModel) {
        ViewModel = viewModel;
        InitializeComponent();
        SetupDatePicker();
    }

    // =========================
    // UI Setup
    // =========================
    private void SetupDatePicker() {
        DatePicker.Date = DateTimeOffset.Now.Date;
    }

    // =========================
    // Property Change Methods
    // =========================
    private void DatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args) {
        if (sender is CalendarDatePicker datePicker && datePicker.Date is DateTimeOffset dateTimeOffset) {
            var dateTime = dateTimeOffset.DateTime.Date;
            ViewModel.Date = dateTime;
        }
    }

    private void TextChanged(object sender, TextChangedEventArgs e) {
        if (sender is TextBox textbox && textbox.Text.NormalizeString() is string text)
            ViewModel.Description = text;
    }
}
