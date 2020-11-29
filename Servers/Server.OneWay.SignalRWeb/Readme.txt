Server.OneWay.SignalRWeb:
A server which sends data to clients via SignalR and receives REST requests via HTTP.
The project makes use of: 
- Default IoC provided with ASP.NET Core 3.1
- Default Microsoft.Extensions.Logger provided with ASP.NET Core 3.1
- Swagger for documenting and testing the REST API

The server sends the current time to clients every 5 seconds via SignalR. 
The server listens for 'Add' requests from clients via HTTP.

Communication is done over HTTPS