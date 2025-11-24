using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CDOWin.Views;

public sealed partial class POsPage : Page {
    public POsViewModel ViewModel { get; }

    public POsPage() {
        InitializeComponent();

        ViewModel = AppServices.POsViewModel;
        DataContext = ViewModel;
    }
}
