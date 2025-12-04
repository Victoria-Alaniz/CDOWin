using CDO.Core.Models;
using Microsoft.UI.Xaml.Controls;

namespace CDOWin.Views.Dialogs;

public sealed partial class UpdateContacts : Page {
    private Client? _client;
    public Client? selectedClient;

    public UpdateContacts(Client client) {
        _client = client;
        selectedClient = _client;
        InitializeComponent();
        DataContext = selectedClient;
    }
}
