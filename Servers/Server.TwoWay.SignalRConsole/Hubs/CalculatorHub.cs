using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.TwoWay.SignalRConsole.Hubs
{
    public class CalculatorHub : Hub
    {
        private ILogger<CalculatorHub> _logger;
        public CalculatorHub(ILogger<CalculatorHub> logger)
        {
            _logger = logger;
        }

        //Push
        public async Task SendDateTimeAsync()
        {
            if (Clients == null)
                return;

            await Clients.All.SendAsync("CurrentTime", DateTime.Now);
        }

        //Pull
        public async Task<double> Add(double num1, double num2)
        {
            var res = num1 + num2;
            _logger.LogInformation("Add result: {num1} + {num2} = {res}", num1, num2, res);

            return await Task.FromResult(num1 + num2);
        }
    }
}
