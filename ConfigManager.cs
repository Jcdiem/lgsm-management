using Renci.SshNet;
using System;
using IniParser;
using IniParser.Model;

namespace lgsm_mngr {
    class ConfigManager {        
        FileIniDataParser parser = new FileIniDataParser();
        private enum ConfigValues : int {
            PORT = 0,
            HOST = 1,
            USER = 2,
            KEY = 3
        }
        //Specify the folder containing user secrets and other non-git data
        // private string sensitiveFolder = "user-data/";
        
        public IniData parseFile(string fileName) {
            if (System.IO.File.Exists(fileName)) {
                IniData rawData = parser.ReadFile(fileName);                
                System.Console.WriteLine("Raw data: ");
                Console.WriteLine(rawData);
            }
            throw new Exception("Config file not found");           
        }

        public ConnectionInfo getConDetails(string fileName){
            if (System.IO.File.Exists(fileName)) {
                IniData rawData = parser.ReadFile(fileName);
                PrivateKeyAuthenticationMethod privKeyAuth = new PrivateKeyAuthenticationMethod(
                    rawData["Connection"]["Username"], 
                    new PrivateKeyFile(rawData["Connection"]["Key"])
                );
                return new ConnectionInfo(
                    rawData["Connection"]["Host"],
                    rawData["Connection"]["Port"],
                    privKeyAuth
                );
            }
            throw new Exception("Config file not found");   
        }
    }
}
