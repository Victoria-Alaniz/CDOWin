using CDOWin.Controls;
using CDOWin.Services;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;


namespace CDOWin.Views;

public sealed partial class CalendarWindow : Window {
    private CalendarViewModel ViewModel { get; }
    public CalendarWindow() {
        InitializeComponent();
        ViewModel = AppServices.CalendarViewModel;
        ViewModel.BuildCalendarDays();
        SetupWindow();
        BuildCalendar();
    }

    private void SetupWindow() {
        ExtendsContentIntoTitleBar = true;
        // Setup Title bar
        var uiSettings = new Windows.UI.ViewManagement.UISettings();
        var accentColor = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent);
        AppWindow.TitleBar.ButtonForegroundColor = accentColor;

        // Set sizing and center the Window
        var manager = WinUIEx.WindowManager.Get(this);
        manager.MinHeight = 600;
        manager.MinWidth = 800;
    }

    void BuildCalendar() {
        MonthHeader.Text = ViewModel.CurrentMonth.ToString("MMMM yyyy");
        CalendarGrid.Children.Clear();

        for (int i = 0; i < ViewModel.Days.Count; i++) {
            if (!ViewModel.Days[i].IsCurrentMonth) {
                var emptyDayView = new EmptyCalendarDay();
                Grid.SetRow(emptyDayView, i / 7);
                Grid.SetColumn(emptyDayView, i % 7);

                CalendarGrid.Children.Add(emptyDayView);
                continue;
            }

            var day = ViewModel.Days[i];
            var dayView = new CalendarDayView {
                Date = day.Date,
                Reminders = day.Reminders
            };

            Grid.SetRow(dayView, i / 7);
            Grid.SetColumn(dayView, i % 7);

            CalendarGrid.Children.Add(dayView);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
        if(sender is Button button && button.Tag is string tag) {
            Debug.WriteLine("BUTTON CLICKED");
            if (tag == "0") {
                ViewModel.DecrementMonth();
                BuildCalendar();
            } else {
                ViewModel.IncrementMonth();
                BuildCalendar();
            }
        }
    }
}
