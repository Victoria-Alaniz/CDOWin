using CDOWin.Services;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace CDOWin.Views;

public sealed partial class StatesPage : Page {
    public StatesViewModel ViewModel { get; }
    public StatesPage() {
        InitializeComponent();

        ViewModel = AppServices.StatesViewModel;
        DataContext = ViewModel;
    }
}
