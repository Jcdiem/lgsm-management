using System;
using System.Collections.Generic;

namespace lgsm_mngr.tui.menus{
    class MainMenu : IMenu {

        public MainMenu(Services.ConnectionManager connectionManager){
            menuTitle = "LGSM Manager Debug Menu";
            choiceList = new List<String>{
                "Read Config",
                "Run Test Command",
                "View Server Info (Not yet implemented)",
                "Quit"};
            con = connectionManager;
        }
        Services.ConnectionManager con;
        public String menuTitle {get;}
        public List<String> choiceList {get;}

        public void handleMenu(){
            bool isRunning = true;
            while (isRunning)
            {
                //Main menu
                switch (TerminalInterface.queryUser(choiceList,menuTitle)){
                    case 1: //Read Config
                        Utils.ConfigManager.readToStringList("user-data/config.ini");
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