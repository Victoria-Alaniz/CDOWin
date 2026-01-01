using CDO.Core.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;

namespace CDOWin.Controls;

public sealed partial class CalendarDayView : UserControl {
    public DateTime Date {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    public static readonly DependencyProperty DateProperty = DependencyProperty.Register(
        nameof(Date),
        typeof(DateTime),
        typeof(CalendarDayView),
        new PropertyMetadata(DateTime.MinValue)
    );

    public ObservableCollection<Reminder> Reminders {
        get => (ObservableCollection<Reminder>)GetValue(RemindersProperty);
        set => SetValue(RemindersProperty, value);
    }

    public static readonly DependencyProperty RemindersProperty = DependencyProperty.Register(
        nameof(Reminders),
        typeof(ObservableCollection<Reminder>),
        typeof(CalendarDayView),
        new PropertyMetadata(null)
    );

    public CalendarDayView() {
        InitializeComponent();
    }
}
