document.addEventListener("DOMContentLoaded", (event) => {
  let syncButton = document.getElementById('sendSyncBtn');
  if (syncButton == null) console.error('Broken element');
  syncButton.addEventListener('click', () => {
  window.api.send('async-msg', 'Testing...');
  window.api.receive('async-reply', (data) => {
    document.getElementById('asyncReply').innerHTML = data;
  });
});
});
