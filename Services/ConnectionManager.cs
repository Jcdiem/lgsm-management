using System;
using Renci.SshNet;

namespace lgsm_mngr.Services
{
    class ConnectionManager : IService {
        SshClient shClient; //SSH Client
        SftpClient sfClient; //SFTP Client
        ConnectionInfo conInfo; //Protocol agnostic connection details

    //TODO: Make config file dynamic and shared between services
        private String configFile = "user=data/config.ini";

        public bool isRunning {get; private set;}

        public ConnectionManager(){
            isRunning = false;
        }

        public void startService(){
            try{
                connectSSH();
                isRunning = true;
            }
            catch(Exception e){
                isRunning = false;
                Console.WriteLine("ERROR: Config not loading!");
                Console.WriteLine("Exception: " + e.Message);
                //TODO: Signal an error to program
            }
            
        }

        public void stopService(){
            //Kill running connections
            //Cleanup
            //Mark done
            isRunning = false;
        }

        public void connectSSH() {
            if (conInfo != null){
                using (shClient = new SshClient(conInfo)) {
                    shClient.Connect();                    
                    if(shClient.IsConnected) Console.WriteLine("DEBUG: SSH connection established!");                    
                    else {                    
                        Console.WriteLine("ERROR: SSH Connection not established!");
                        throw new Exception("SSH Connection failed");
                    }
                }
            }
            else throw new Exception("No connection info!");            
        }

        private void reloadConfig(){
            conInfo = Services.ConfigManager.getConDetails(configFile);
        }
    }
}
