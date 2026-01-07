using CDOWin.Extensions;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Diagnostics;

namespace CDOWin.Views.ServiceAuthorizations.Dialogs;

public sealed partial class CreateServiceAuthorization : Page {

    // =========================
    // Dependencies
    // =========================
    private readonly CreateServiceAuthorizationsViewModel ViewModel;

    // =========================
    // Constructor
    // =========================
    public CreateServiceAuthorization(CreateServiceAuthorizationsViewModel viewModel) {
        ViewModel = viewModel;
        InitializeComponent();
        SetupDatePickers();
    }

    // =========================
    // UI Setup
    // =========================
    private void SetupDatePickers() {
        DateTimeOffset date = DateTime.Now;
        StartDatePicker.Date = date;
        EndDatePicker.Date = date;
    }

    // =========================
    // Property Change Methods
    // =========================
    private void DatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args) {
        if (sender is not CalendarDatePicker datePicker || datePicker.Tag is not DateType dateType)
            return;
        
        if (datePicker.Date is DateTimeOffset offset) {
            switch (dateType) {
                case DateType.StartDate:
                    ViewModel.StartDate = offset.Date.ToUniversalTime();
                    break;
                case DateType.EndDate:
                    ViewModel.EndDate = offset.Date.ToUniversalTime();
                    break;
            }
        }
    }

    private void TextChanged(object sender, TextChangedEventArgs e) {
        if (sender is not TextBox textBox || textBox.Tag is not Field field)
            return;

        var text = textBox.Text.NormalizeString();

        if (string.IsNullOrWhiteSpace(text)) return;

        switch (field) {
            case Field.Id:
                break;
            case Field.ClientID:
                break;
            case Field.CounselorID:
                break;
            case Field.Description:
                break;
            case Field.Office:
                break;
            case Field.UoM:
                break;
        }
    }

    private void NumberBox_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args) {

    }
}
