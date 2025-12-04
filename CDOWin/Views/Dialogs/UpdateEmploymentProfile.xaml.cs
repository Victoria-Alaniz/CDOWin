using CDO.Core.Models;
using Microsoft.UI.Xaml.Controls;

namespace CDOWin.Views.Dialogs;

public sealed partial class UpdateEmploymentProfile : Page {
    private Client? _client;
    public Client? selectedClient;
    public UpdateEmploymentProfile(Client client) {
        _client = client;
        selectedClient = _client;
        InitializeComponent();
        DataContext = selectedClient;
    }
}
