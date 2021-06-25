using System;
using Renci.SshNet;

namespace lgsm_mngr
{
    class ConnectionManager {
        SshClient shClient; //SSH Client
        SftpClient sfClient; //SFTP Client
        ConnectionInfo conInfo; //Protocol agnostic connection details

        public ConnectionManager(string host, string username, int port, string privKeyFile) {
            ConnectionInfo conInfo = new ConnectionInfo(
                host,
                port,
                username,
                new PrivateKeyAuthenticationMethod("user-data/"+privKeyFile)
                );
        }

        public void connectSSH() {
            using (shClient = new SshClient(conInfo)) {
                shClient.Connect();
            }
        }
    }
}
