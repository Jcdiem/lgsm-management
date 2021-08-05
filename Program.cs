using System;
using lgsm_mngr.Services;

namespace lgsm_mngr
{
    public class Program
    {
        public static void Main(string[] args){
            ServiceManager serviceManager = new ServiceManager();
            
            //Basic UI for testing
            tui.TerminalInterface.startUI(serviceManager);
            

        }        
    }
}
