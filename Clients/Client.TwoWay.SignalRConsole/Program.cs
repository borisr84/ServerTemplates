using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Client.TwoWay.SignalRConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/calculatorHub")
                .Build();

            connection.On("CurrentTime", (DateTime dt) =>
            {
                Console.WriteLine($"Current time = {dt}");
            });
            await connection.StartAsync();

            await Task.Run(async () =>
            {
                while (true) 
                { 
                    await Task.Delay(5 * 1000);
                    var res = await connection.InvokeAsync<double>("Add", 2, 3.5);
                    Console.WriteLine($"Add result = {res}");
                }
            });

            //Console.ReadKey();
        }
    }
}
