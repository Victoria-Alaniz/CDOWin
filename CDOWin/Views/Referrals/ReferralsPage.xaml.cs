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
}
