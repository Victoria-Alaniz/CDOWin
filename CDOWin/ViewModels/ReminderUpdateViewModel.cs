using CDO.Core.DTOs;
using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CDOWin.ViewModels;

public partial class ReminderUpdateViewModel : ObservableObject {
    public Reminder Original;
    public UpdateReminderDTO Updated = new UpdateReminderDTO();

    public ReminderUpdateViewModel(Reminder reminder) {
        Original = reminder;
    }
}
