using System;
using Renci.SshNet;

namespace lgsm_mngr
{
    class ConnectionManager {
        SshClient shClient; //SSH Client
        SftpClient sfClient; //SFTP Client
        ConnectionInfo conInfo; //Protocol agnostic connection details

        public ConnectionManager(ConnectionInfo connectionDetails) {
            conInfo = connectionDetails;
        }

        public void connectSSH() {
            using (shClient = new SshClient(conInfo)) {
                shClient.Connect();
            }
        }
    }
}
