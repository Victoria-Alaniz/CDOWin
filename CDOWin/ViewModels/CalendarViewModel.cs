using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

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

        var firstOfMonth = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1);
        var firstVisibleDay = firstOfMonth.AddDays(-(int)firstOfMonth.DayOfWeek);

        var remindersByDate = _remindersViewModel.GetRemindersByMonth(firstOfMonth);

        for (int i = 0; i < 42; i++) {
            var date = firstVisibleDay.AddDays(i);

            Days.Add(new CalendarDay(date, date.Month == CurrentMonth.Month) {
                Reminders = new ObservableCollection<Reminder>(
                    remindersByDate.GetValueOrDefault(date.Date) ?? []
                    )
            });
        }
    }

    public void SetCurrentMonth() {
        if (CurrentMonth.Month == DateTime.Now.Month) return;
        CurrentMonth = DateTime.Now;
        BuildCalendarDays();
    }

    public void IncrementMonth() {
        Debug.WriteLine($"Incrementing Date");
        CurrentMonth = CurrentMonth.AddMonths(1);
        BuildCalendarDays();
    }

    public void DecrementMonth() {
        CurrentMonth = CurrentMonth.AddMonths(-1);
        BuildCalendarDays();
    }
}
