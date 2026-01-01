using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CDOWin.ViewModels;

public partial class CalendarViewModel : ObservableObject {
    private readonly RemindersViewModel _remindersViewModel;

    public DateTime CurrentMonth { get; private set; } = DateTime.Today;
    public ObservableCollection<CalendarDay> Days { get; }

    public CalendarViewModel(RemindersViewModel viewModel) {
        _remindersViewModel = viewModel;
        Days = [];
    }

    public void BuildCalendarDays() {
        Days.Clear();

        // Get the first Sunday of the Calendar
        DateTime firstOfMonth = new(CurrentMonth.Year, CurrentMonth.Month, 1);
        int dayOfWeekOffset = (int)firstOfMonth.DayOfWeek;
        DateTime firstVisibleDay = firstOfMonth.AddDays(-dayOfWeekOffset);
        var remindersByDate = _remindersViewModel.GetRemindersByMonth(firstOfMonth);

        for (int i = 0; i < 42; i++) {
            DateTime date = firstVisibleDay.AddDays(i);
            bool isCurrentMonth = date.Month == CurrentMonth.Month;
            var calendarDay = new CalendarDay(date, isCurrentMonth);
            calendarDay.Reminders = new ObservableCollection<Reminder>(
                remindersByDate.GetValueOrDefault(date.Date) ?? []
                );
            Days.Add(calendarDay);
        }
    }
}
