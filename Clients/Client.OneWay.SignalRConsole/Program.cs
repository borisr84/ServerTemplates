using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Client.OneWay.SignalRConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44304/dateTimeHub")
                .Build();

            connection.On("CurrentTime", (DateTime dt) =>
            {
                Console.WriteLine($"Current time = {dt}");
            });
            await connection.StartAsync();
            await connection.InvokeAsync("StartDateTimePolling");

            await Task.Run(async () =>
            {
                while (true) 
                { 
                    await Task.Delay(5 * 1000);
                }
            });

            //Console.ReadKey();
        }
    }
}
