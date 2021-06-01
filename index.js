//Global Space
const path = require('path')
const {app, BrowserWindow } = require('electron')
const {readFileSync } = require('fs');
const {Client } = require('ssh2');

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
        if(sshCmd(conn,'whoami') != null) goodConnect = true;
    });

    if(goodConnect) return conn;
    else {
        console.error('SSH connection failed!');
        return null;
    }
}

/**
 * Run a command in a server connected via SSH
 * @param {Client} conn The SSH connection to use
 * @param {String} cmd The command to be run on the server
 * @returns {object} STDOUT and STDERR in strings
 */
function sshCmd(conn,cmd){
    cmdOutput = {err: "", out: ""};
    conn.exec(cmd, (err, stream) => {            
        if (err) throw err;
        //Once done receiving data
        stream.on('close', (code, signal) => {
            console.debug('Stream :: close :: code: ' + code + ', signal: ' + signal);
            conn.end();                
        }).on('data', (stdout) =>{ //Get the STDOUT
            cmdOutput.out = stdout;
        }).stderr.on('data', (stderr) =>{ //Get the STDERR
            cmdOutput.err = stderr;
        });
    });
    return cmdOutput;
}



app.whenReady().then(() => {
    //Runtime

    //Create window and load main menu
    win = new BrowserWindow({width:800,height:600,title:'Linux GSM Manager',titleBarStyle:'hidden'});
    //win.loadfile('main menu');
    win.loadFile('UI/html/testScreen.html');

})