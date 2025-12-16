using CDO.Core.DTOs;
using CDO.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CDOWin.ViewModels;

public partial class ReferralUpdateViewModel : ObservableObject {
    public Referral Original;
    public ReferralDTO Updated = new ReferralDTO();

    public ReferralUpdateViewModel(Referral referral) {
        Original = referral;
    }
}
