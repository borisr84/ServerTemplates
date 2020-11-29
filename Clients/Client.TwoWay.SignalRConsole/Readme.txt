Client.TwoWay.SignalRConsole:
A client console for testing the communication with server using SignalR for sending and receving data from server.
The client constantly listens for incoming data from server and sends to the client 'Add' operation request each 5 seconds via SignalR

The client listens for current time reports from server. 
The client sends 'Add' request to server and awaits its result every 5 seconds.