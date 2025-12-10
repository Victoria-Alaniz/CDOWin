using CDOWin.ViewModels;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using System.Threading.Tasks;
using WinRT.Interop;

namespace CDOWin.Views;

public sealed partial class CounselorsPage : Page {
    public CounselorsViewModel ViewModel { get; }

    public CounselorsPage() {
        InitializeComponent();
        ViewModel = AppServices.CounselorsViewModel;
        Debug.WriteLine(ViewModel.Counselors.Count);
        DataContext = ViewModel;
    }
}
