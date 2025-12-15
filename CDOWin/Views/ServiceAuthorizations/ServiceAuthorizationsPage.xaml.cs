using CDO.Core.Models;
using CDOWin.Services;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace CDOWin.Views.ServiceAuthorizations;

public sealed partial class ServiceAuthorizationsPage : Page {
    public ServiceAuthorizationsViewModel ViewModel { get; }

    public ServiceAuthorizationsPage() {
        InitializeComponent();
        ViewModel = AppServices.POsViewModel;
        DataContext = ViewModel;
    }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e) {
        if(e.ClickedItem is ServiceAuthorization sa) {
            ViewModel.RefreshSelectedServiceAuthorization(sa.id);
        }
    }
}
