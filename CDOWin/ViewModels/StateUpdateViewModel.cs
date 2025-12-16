using CDO.Core.DTOs;
using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CDOWin.ViewModels;

public partial class StateUpdateViewModel : ObservableObject {
    public State Original;
    public UpdateStateDTO Updated = new UpdateStateDTO();

    public StateUpdateViewModel(State state) {
        Original = state;
    }
}

