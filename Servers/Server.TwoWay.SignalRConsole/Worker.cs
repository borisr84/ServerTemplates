using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.TwoWay.SignalRConsole.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.TwoWay.SignalRConsole
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly CalculatorHub _calculatorHub;

        public Worker(ILogger<Worker> logger, IConfiguration config, CalculatorHub calculatorHub)
        {
            _logger = logger;
            _calculatorHub = calculatorHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _calculatorHub.SendDateTimeAsync();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
