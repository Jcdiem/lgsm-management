//Global Space
const path = require('path')
const {app, BrowserWindow, ipcMain } = require('electron')
const {readFileSync } = require('fs');
const {Client } = require('ssh2');
const { resolve } = require('path');

/**
 * Run asynchronys command in a server connected via SSH
 * @param {Object} connDetails {host,port,username,privKey}
 * @param {String} cmd The command to be run on the server
 * @returns {Promise} Promise with resolve of cmd output
 */
function asyncSshSimpleCmd(connDetails,cmd){
    if (cmd == null) console.error("asyncSshSimpleCmd Missing command to send");
    return new Promise(function(resolve, reject){
            cmdOutput = "";
            const conn = new Client();
            conn.on('ready', () => {
                //Client ready
                conn.exec(cmd, (err, stream) => {            
                    if (err) reject(err);
                    stream.on('close', (code, signal) => { //Command finished
                        console.debug('Stream :: close :: code: ' + code + ', signal: ' + signal);
                        conn.end();
                    }).on('data', (stdout) =>{ //Get the STDOUT
                        cmdOutput = stdout;
                        console.log(cmdOutput);
                        resolve(cmdOutput)
                        //Testing
                    }).stderr.on('data', (stderr) =>{ //Get the STDERR
                        cmdOutput = stderr;
                        console.log(cmdOutput);
                        resolve(cmdOutput);
                    });
                }); 
            }).connect({
                host: connDetails.host,
                port: connDetails.port,
                username: connDetails.username,
                privateKey: readFileSync(connDetails.privKey)
            })
                       
    });
}



app.whenReady().then(() => {
    //Runtime

    //Create window and load main menu
    win = new BrowserWindow({
        width:800,
        height:600,
        title:'Linux GSM Manager',
        titleBarStyle:'hidden',
        webPreferences:{
            preload: path.join(__dirname, 'UI/preload/testScreen.js'),
            contextIsolation: true,
            enableRemoteModule: false
        }
    });
    //win.loadfile('main menu');
    win.loadFile('UI/testScreen.html');

    ipcMain.on('ssh-connect', (event, arg) => {
        console.log(arg);
        cmdPromise = asyncSshSimpleCmd(arg,'whoami');
        event.sender.send('async-reply','Working on it....');
        cmdPromise.then(function(result){
            console.debug('result connect: ' + result);
            event.sender.send('async-reply','Server replied: ' + result);
        }), function(err){
            event.sender.send('async-reply','error in ssh configuration <br> ' + err);
            console.debug(err);
        }        
    });

})