using WinUIEx;

namespace CDOWin.Views;

public sealed partial class SplashWindow : WinUIEx.WindowEx {
    public SplashWindow() {
        InitializeComponent();

        ExtendsContentIntoTitleBar = true;
        IsMinimizable = false;
        IsMaximizable = false;

        var manager = WindowManager.Get(this);
        manager.MinWidth = 400;
        manager.MaxWidth = 400;
        manager.MinHeight = 250;
        manager.MaxHeight = 250;


        this.CenterOnScreen();
    }
}
