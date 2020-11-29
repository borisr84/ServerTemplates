Server.TwoWay.SignalRConsole:
Worker Service SignalR server which both sends and receives data/requests via SignalR.
The project makes use of: 
- Default IoC provided with ASP.NET Core 3.1
- Microsoft.Extensions.Logger provided with ASP.NET Core 3.1

The server sends the current time to clients every second. 
The server listens for 'Add' requests from clients.

Communication is done over HTTPS