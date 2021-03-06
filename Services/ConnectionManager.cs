using System;
using Renci.SshNet;

namespace lgsm_mngr.Services
{
    class ConnectionManager : IService {
        SshClient shClient; //SSH Client
        SftpClient sfClient; //SFTP Client
        ConnectionInfo conInfo; //Protocol agnostic connection details

    //TODO: Make config file dynamic and shared between services
        public String configFile {get; private set;}

        public bool isRunning {get; private set;}

        public ConnectionManager(){
            configFile = "user-data/config.ini";
            isRunning = false;
            reloadConfig();
        }

        public void startService(){
            try{
                connectSSH();
                isRunning = true;
            }
            catch(Exception e){
                isRunning = false;
                Console.WriteLine("ERROR: SSH connection failed!");
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
                shClient = new SshClient(conInfo);
                shClient.Connect();                    
                if(shClient.IsConnected) Console.WriteLine("DEBUG: SSH connection established!");                    
                else {                    
                    Console.WriteLine("ERROR: SSH Connection not established!");
                    throw new Exception("SSH Connection failed");
                }                
            }
            else throw new Exception("No connection info!");            
        }

        //Returns message
        public String sendShellCommand(String cmd) {
            String cmdText = cmd;
            if(isRunning){
                Console.WriteLine("DEBUG: Sending ssh command  \'" + cmdText + "\'");
                SshCommand command = shClient.RunCommand(cmdText);
                Console.WriteLine("Result: "+ command.Result);
                return "";                
            }
            else throw new Exception("SSH command sent without running connection");
        }

        public async void runAsyncCommand(String cmd){
            Console.WriteLine("DEBUG: Creating ssh command: " + cmd + "\n");
            SshCommand shCmd = shClient.CreateCommand(cmd);            
            Console.WriteLine("DEBUG: SSH command created, running...");
            shCmd.BeginExecute();
            while(shCmd.ExitStatus)
        }

        private void reloadConfig(){
            conInfo = Utils.ConfigManager.getConDetails(configFile);
        }
    }
}
