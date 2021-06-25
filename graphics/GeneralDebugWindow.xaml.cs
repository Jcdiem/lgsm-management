using System;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace lgsm_mngr.graphics {
    //Create class that inherits from Avalonia's window system
    class GeneralDebugWindow : Window {
        //Initialize everything on construction
        public GeneralDebugWindow() {
            initComponent();
        }

        //Attach UI elements to the code
        private void initComponent() {
            //Create window
            AvaloniaXamlLoader.Load(this);
            //Find named controls
            var testButton = this.FindControl<Button>("DebugBtn");
        }


        public void namedClickEvent(object sender, RoutedEventArgs args) {
            Console.WriteLine("Button was clicked");
        }
    }
}
