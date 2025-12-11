using CDOWin.Services;
using CDOWin.ViewModels;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Linq;
using Windows.UI;

namespace CDOWin.Views;

public sealed partial class RemindersPage : Page {
    public RemindersViewModel ViewModel { get; }

    public RemindersPage() {
        InitializeComponent();

        ViewModel = AppServices.RemindersViewModel;
        DataContext = ViewModel;
    }

    private void RemindersCalendar_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args) {
        // Render basic day items.
        if (args.Phase == 0) {
            // Register callback for next phase.
            args.RegisterUpdateCallback(RemindersCalendar_CalendarViewDayItemChanging);
        } else if (args.Phase == 1) {
            DateTime day = args.Item.Date.Date;

            // Does any reminder match this date?
            bool hasReminder = ViewModel.Reminders.Any(r => r.date.Date == day);

            if (hasReminder) {
                // Mark the date (simple highlight)
                Color accentColor = (Color)Application.Current.Resources["SystemAccentColorLight1"];
                args.Item.Background = new SolidColorBrush(accentColor);
                args.Item.FontWeight = FontWeights.Bold;
            } else {
                // Reset to defaults when not a reminder date
                args.Item.Background = null;
                args.Item.FontWeight = FontWeights.Normal;
            }
        }
    }
}
