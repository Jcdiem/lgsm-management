using Avalonia;
using System;

namespace lgsm_mngr {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Loading...");

            ConfigManager cfg = new ConfigManager();
            ConnectionManager conMngr = new ConnectionManager(cfg.parseFile("ConnectionDetails.txt"));

            conMngr.connectSSH();

            //UI Testing

            //Build the UI application
            AppBuilder.Configure<GUI>()
                .UsePlatformDetect()
                .LogToTrace()
                .StartWithClassicDesktopLifetime(args);
        }
    }

}
