using CDO.Core.Models;
using CDOWin.Services;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace CDOWin.Views.Counselors;

public sealed partial class CounselorsPage : Page {
    public CounselorsViewModel ViewModel { get; }

    public CounselorsPage() {
        InitializeComponent();
        ViewModel = AppServices.CounselorsViewModel;
        DataContext = ViewModel;
    }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e) {
        if(e.ClickedItem is Counselor counselor) {
            ViewModel.RefreshSelectedCounselor(counselor.id);
        }
    }
}
