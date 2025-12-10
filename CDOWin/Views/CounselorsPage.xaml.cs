using CDOWin.ViewModels;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using System.Threading.Tasks;
using WinRT.Interop;
using WinUI.TableView;

namespace CDOWin.Views;

public sealed partial class CounselorsPage : Page {
    public CounselorsViewModel ViewModel { get; }

    public CounselorsPage() {
        InitializeComponent();
        ViewModel = AppServices.CounselorsViewModel;
        Debug.WriteLine(ViewModel.Counselors.Count);
        DataContext = ViewModel;
    }

    private async void OnExportAllContent(object sender, TableViewExportContentEventArgs e) {

    }

    private async void OnExportSelectedContent(object sender, TableViewExportContentEventArgs e) {

    }
}
