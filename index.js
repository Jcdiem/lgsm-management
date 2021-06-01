//Global Space
const path = require('path')
const {BrowserWindow } = require('electron')
const {readFileSync } = require('fs');
const {Client } = require('ssh2');

function createWindow () {
    const win = new BrowserWindow({
      width: 800,
      height: 600
    })
  
    win.loadFile('UI/html/testScreen.html')
}


app.whenReady().then(() => {
    //Runtime
    
    /**
     * Create an OpenSSH client connection to the server
     * @param {String} priv The path of the private key of the user
     * @param {String} user The user to connect as
     * @param {String} host The host running an OpenSSH server
     * @param {number} port Port number to connect to the server on
     * @returns {Client} An open SSH connection to the server
     */
    function createSSH(priv,user,host,port){
        conn = new Client();
        conn.connect({
            host: host,
            port: port,
            username: user,
            privateKey: readFileSync(priv)
        });

        //Assume connection is bad
        goodConnect = false;

        conn.on('ready', () =>{
            console.debug('SSH connection established, attempting test command.');
            conn.exec('uptime')
        });
        
        if(goodConnect) return conn;
        else {
            console.error('SSH connection failed!');
            return null;
        }
    }


    createWindow();
})