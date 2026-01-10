using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;


namespace CDOWin.Views.Placements.Dialogs;

public sealed partial class CreatePlacements : Page {

    // =========================
    // Dependencies
    // =========================
    private readonly CreatePlacementViewModel ViewModel;

    public CreatePlacements(CreatePlacementViewModel viewModel) {
        ViewModel = viewModel;
        InitializeComponent();
    }

    // When the employer is selected, prefill the supervisor/phone/email if the item is empty
}
