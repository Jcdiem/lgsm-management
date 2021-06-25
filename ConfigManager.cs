using Renci.SshNet;
using System;

namespace lgsm_mngr {
    class ConfigManager {
        private enum ConfigValues : int {
            PORT = 0,
            HOST = 1,
            USER = 2,
            KEY = 3
        }
        //Specify the folder containing user secrets and other non-git data
        private string sensitiveFolder = "user-data/";

        ConnectionInfo configDetails;
        public ConnectionInfo parseFile(string fileName) {
            if (System.IO.File.Exists(sensitiveFolder+fileName)) {
                
                //Create array of config lines
                string[] cfg = System.IO.File.ReadAllLines(sensitiveFolder + fileName);

                //Check for consistency between expected lines and actual
                if (cfg.Length != Enum.GetNames(typeof(ConfigValues)).Length) throw new Exception("Config file has wrong amount of lines");

                //Format every line in file to just be the value
                for (int i = 0; i < cfg.Length; i++) {
                    cfg[i] = cfg[i].Split(':')[1].Trim();
//                    Console.WriteLine("Value: " + cfg[i]);
                }

                //Error check for bad privkey
                if (System.IO.File.Exists(sensitiveFolder + cfg[(int)ConfigValues.KEY])) {

                    //Create the connection info using the values
                    configDetails = new ConnectionInfo(
                        cfg[(int)ConfigValues.HOST], //IP-address or Hostname
                        Convert.ToInt32(cfg[(int)ConfigValues.PORT]), //Port
                        cfg[(int)ConfigValues.USER], //Username
                        //Last one is private key
                        new PrivateKeyAuthenticationMethod(cfg[(int)ConfigValues.USER], new PrivateKeyFile(sensitiveFolder + cfg[(int)ConfigValues.KEY]))
                    );
                    //TODO: switch to standardized config               
                    return configDetails;
                }
                throw new UriFormatException("Could not find private key");
                

            }
            throw new Exception("Config file not found");           
        }
    }
}
