using Renci.SshNet;
using System;
using System.Collections.Generic;
using IniParser;
using IniParser.Model;

namespace lgsm_mngr.Services {
    class ConfigManager {        
        
        private enum ConfigValues : int {
            PORT = 0,
            HOST = 1,
            USER = 2,
            KEY = 3
        }
        //Specify the folder containing user secrets and other non-git data
        // private string sensitiveFolder = "user-data/";
        
        private static IniData readIni(string fileName) {
            FileIniDataParser parser = new FileIniDataParser();
            if (System.IO.File.Exists(fileName)) {
                IniData rawData = parser.ReadFile(fileName);
                System.Console.WriteLine("DEBUG: Config file read from INI to below \n" + rawData);
                return rawData;
            }
            else throw new Exception("Config file not found");            
        }

        //TODO: Import to printable format
        public List<String> readToStringList(String file){
            return new List<String>();
        }

        public static ConnectionInfo getConDetails(string fileName){

            //TODO: ISSUE#1 (Automate update of secret location)
            String sensitiveFolder = "user-data/";

            if (System.IO.File.Exists(fileName)) {
                IniData rawData = readIni(fileName);
                PrivateKeyAuthenticationMethod privKeyAuth = new PrivateKeyAuthenticationMethod(
                    rawData["Connection"]["User"], 
                    new PrivateKeyFile(sensitiveFolder + rawData["Connection"]["Key"])
                );
                return new ConnectionInfo(
                    rawData["Connection"]["Host"],
                    rawData["Connection"]["User"],
                    privKeyAuth                    
                );
            }
            throw new Exception("Config file not found");   
        }
    }
}
