using CDOWin.Services;
using CDOWin.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace CDOWin.Views.Placements.Inspectors;

public sealed partial class PlacementInspector : Page {

    // =========================
    // ViewModel
    // =========================
    public PlacementsViewModel ViewModel { get; } = AppServices.PlacementsViewModel;

    // =========================
    // Constructor
    // =========================
    public PlacementInspector() {
        InitializeComponent();
    }
}
