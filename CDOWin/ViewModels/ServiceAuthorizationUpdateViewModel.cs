using CDO.Core.DTOs;
using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CDOWin.ViewModels;

public partial class ServiceAuthorizationUpdateViewModel : ObservableObject {
    public ServiceAuthorization Original;
    public UpdateServiceAuthorizationDTO Updated = new UpdateServiceAuthorizationDTO();

    public ServiceAuthorizationUpdateViewModel(ServiceAuthorization serviceAuthorization) {
        Original = serviceAuthorization;
    }
}
