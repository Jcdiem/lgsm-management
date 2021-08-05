using System;
using System.Collections.Generic;
using lgsm_mngr.Services;

namespace lgsm_mngr.tui.menus{
    class MainMenu : IMenu {

        public MainMenu(ConnectionManager connectionManager){
            menuTitle = "LGSM Manager Debug Menu";
            choiceList = new List<String>{
                "Read Config",
                "Run Test Command",
                "View Server Info (Not yet implemented)",
                "Quit"};
            con = connectionManager;
            configManager = new ConfigManager();
        }
        ConnectionManager con;
        ConfigManager configManager;
        public String menuTitle {get;}
        public List<String> choiceList {get;}

        public void handleMenu(){
            bool isRunning = true;
            while (isRunning)
            {
                //Main menu
                switch (TerminalInterface.queryUser(choiceList,menuTitle)){
                    case 1: //Read Config
                        configManager.readToStringList("user-data/config.ini");
                        break;
                    case 2: //Run Test Command
                        con.connectSSH();
                        break;
                    case 3: //View Server Info
                        Console.WriteLine("Not yet implemented!");
                        TerminalInterface.pauseConsole();        
                        break;
                    case 4: //Quit
                        isRunning = false;
                        Console.WriteLine("Quitting...");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}