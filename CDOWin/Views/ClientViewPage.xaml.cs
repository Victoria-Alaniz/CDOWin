using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace CDOWin.Views;

public sealed partial class ClientViewPage : Page {
    public ClientsViewModel ViewModel { get; private set; }
    public ClientViewPage() {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) {
        ViewModel = (ClientsViewModel)e.Parameter;
        DataContext = ViewModel;
    }

    private void ElevatorSpeech_Clicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) {
        var checkbox = (CheckBox)sender;
    }
}
