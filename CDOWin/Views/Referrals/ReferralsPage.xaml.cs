using CDO.Core.Models;
using CDOWin.Services;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;

namespace CDOWin.Views.Referrals;
    
public sealed partial class ReferralsPage : Page {
    public ReferralsViewModel ViewModel { get; }

    public ReferralsPage() {
        InitializeComponent();
        ViewModel = AppServices.ReferralsViewModel;
        Debug.WriteLine(ViewModel.Referrals.Count);
        DataContext = ViewModel;
    }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e) {
        if(e.ClickedItem is Referral referral) {
            ViewModel.RefreshSelectedReferral(referral.id);
        }
    }
}
