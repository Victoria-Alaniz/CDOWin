using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System.Diagnostics;

namespace CDOWin.Views;

public sealed partial class ClientViewPage : Page {
    public ClientsViewModel? ViewModel { get; private set; }
    public ClientViewPage() {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) {
        ViewModel = (ClientsViewModel)e.Parameter;
        DataContext = ViewModel;
    }

    private void Checkbox_Clicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) {
        if (sender is CheckBox checkBox) {
            string? checkboxName = checkBox.Tag?.ToString();
            if (string.IsNullOrEmpty(checkboxName))
                return;
            Debug.WriteLine($"Checkbox: {checkboxName} was checked with value: {checkBox.IsChecked}");
            // here we ask the viewmodel nicely to do our update
        }
    }
    private void OpenDocuments_Clicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) {
        Debug.WriteLine($"Open {ViewModel.SelectedClient?.documentsFolderPath}");
        Process.Start("explorer.exe", $"{ViewModel.SelectedClient?.documentsFolderPath}");
    }
}
