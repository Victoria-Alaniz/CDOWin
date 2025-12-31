using CDO.Core.Constants;
using CDOWin.Services;
using CDOWin.Views;
using Meziantou.Framework.Win32;
using Microsoft.UI.Xaml;

namespace CDOWin;

public partial class App : Application {
    private WindowManager _windowManager;
    private Window? _window;

    public App() {
        _windowManager = WindowManager.Instance;
        InitializeComponent();
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args) {

        if (CredentialManager.ReadCredential(AppConstants.AppName) is { } creds) {
            // Initialize services
            AppServices.InitializeServices(creds.UserName!, creds.Password!);

            // Show the loading splash screen
            _windowManager.ShowSplash();

            // Await the app to load
            var loaded = await AppServices.LoadDataAsync();

            if (loaded == true) {
                _windowManager.ShowMainWindow();
                _windowManager.CloseSplash();
            } else {
                // here we need to add an error window
            }
        } else {
            _window = new LoginWindow();
            _window.Activate();
        }
    }
}
