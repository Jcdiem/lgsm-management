using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using lgsm_mngr.Services;

namespace lgsm_mngr
{
    public class Program
    {
        public static void Main(string[] args){
            ConnectionManager conMan = new ConnectionManager();
            conMan.startService();

            // //Start services            

            // tui.TerminalInterface term = new tui.TerminalInterface();
            // term.startUI();
        }        
    }
}
