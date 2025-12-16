using CDO.Core.DTOs;
using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CDOWin.ViewModels;

public partial class EmployerUpdateViewModel : ObservableObject {
    public Employer Original;
    public EmployerDTO Updated = new EmployerDTO();

    public EmployerUpdateViewModel(Employer employer) {
        Original = employer;
    }
}
