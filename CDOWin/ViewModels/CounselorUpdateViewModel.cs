using CDO.Core.DTOs;
using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CDOWin.ViewModels;

public partial class CounselorUpdateViewModel : ObservableObject {
    public Counselor Original;
    public UpdateCounselorDTO Updated = new UpdateCounselorDTO();

    public CounselorUpdateViewModel(Counselor counselor) {
        Original = counselor;
    }
}
