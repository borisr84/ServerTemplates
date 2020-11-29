using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.OneWay.SignalRWebSerilog.Hubs
{
    public class DateTimeHub : Hub
    {
        private CancellationToken _cancellationToken = new CancellationToken();
        
        public async Task StartDateTimePolling()
        {
            await Task.Run(async () =>
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    await Clients.All.SendAsync("CurrentTime", DateTime.Now);
                    await Task.Delay(5 * 1000);
                }
            }
            );
        }

        public void StopDateTimePolling()
        {
            _cancellationToken.ThrowIfCancellationRequested();
        }
    }
}
