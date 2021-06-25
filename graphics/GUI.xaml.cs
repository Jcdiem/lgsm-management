using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace lgsm_mngr {
    //Create a class derived from application
    public class GUI : Application {

        //Load the XAML file associated
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        //When completed initialize the main window
        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime) {
                //Load the DebugWindow as the main window
                desktopLifetime.MainWindow = new graphics.GeneralDebugWindow();
            }
        }
    }
}