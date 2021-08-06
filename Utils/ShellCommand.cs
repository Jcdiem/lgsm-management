using Renci.SshNet;
using System;
using System.Collections.Generic;

namespace lgsm_mngr.Utils {

    //To be used for commonly repeated/used shell commands
    class ShellCommand {

        //TODO: Finish 4 test utilities
        public static List<String> showRunningServers(Services.ConnectionManager ssh){
            SshCommand craftedCommand = ssh.;
            throw new NotImplementedException();
        }
        
        public static SshCommand installServer(String basedir, Services.ConnectionManager ssh){            
            throw new NotImplementedException();
        }
        
        public static SshCommand listDirectory(){
            throw new NotImplementedException();
        }
        
        public static SshCommand createDirBackup(){
            throw new NotImplementedException();
        }
        
        public static SshCommand updateFactorioMods(){
            throw new NotImplementedException();
        }
    }
}