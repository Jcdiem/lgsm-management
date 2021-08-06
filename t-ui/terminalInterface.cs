using System;
using System.Collections.Generic;

namespace lgsm_mngr.tui
{
    class TerminalInterface
    {
        public static void startUI(ServiceManager srvc)
        {            
            ServiceManager serviceManger = srvc;
            bool isRunning = true;
            while (isRunning)
            {
                //Main menu
                switch (queryUser(new List<String>{
                "Read Config",
                "Run Test Command",
                "View Server Info (Not yet implemented)",
                "Quit"},
                "LGSM Manager Debug Menu"))
                {
                    case 1: //Read Config
                        Utils.ConfigManager.getConDetails(srvc.configLocation);
                        pauseConsole();
                        break;
                    case 2: //Run Test Command
                        if(!srvc.connectionManager.isRunning) srvc.connectionManager.startService();
                        srvc.connectionManager.sendShellCommand("whoami");
                        pauseConsole();
                        break;
                    case 3: //View Server Info
                        Console.WriteLine("Not yet implemented!");
                        pauseConsole();        
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
        //Print a list of options and get the user selection
        public static int queryUser(List<String> choiceList, String title)
        {
            //Default choice should change
            int choice = -1;

            //Create title
            Console.WriteLine("====" + title + "====");
            //Create options
            for (int i = 0; i < choiceList.Capacity; i++)
            {
                Console.WriteLine(i + 1 + ". " + choiceList[i]);
            }

            //Keep asking until proper answer or quit
            while (true)
            {
                //Ask for reply
                Console.Write("Please choose a number: ");

                //Wait for reply
                String input = Console.ReadLine();

                //Quit on 'NO'
                if (input.Equals("NO")) break;

                //Try to parse to number
                try
                {
                    choice = int.Parse(input);
                }
                //Remind to only use numbers if can't parse
                catch (FormatException)
                {
                    Console.WriteLine("Please only use numbers!");
                }

                //Quit on proper selection
                if (choice >= 1 && choice <= choiceList.Capacity) break;

                //Notify user of restart
                Console.WriteLine("Please try again or type \'NO\' to cancel");
            }
            //Ensure choice has changed, else error
            if (choice < 0) throw new Exception("Choice value was not changed!");
            return choice;
        }

        public static void pauseConsole(){
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}