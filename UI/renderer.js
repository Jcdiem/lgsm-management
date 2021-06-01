document.addEventListener("DOMContentLoaded", (event) => {
  let syncButton = document.getElementById('sendSyncBtn');
  if (syncButton == null) console.error('Broken element');
  syncButton.addEventListener('click', () => {
      let hostDetail = document.getElementById('hostInput').value.split(':');
      sshDetails = {
        host:hostDetail[0],
        user:document.getElementById('usernameInput').value,
        privkey:document.getElementById('privkeyInput').value,
        port:hostDetail[1]
      }
      window.api.send('ssh-connect', sshDetails);
      window.api.receive('async-reply', (data) => {
        document.getElementById('asyncReply').innerHTML = data;
      });
  });
});
