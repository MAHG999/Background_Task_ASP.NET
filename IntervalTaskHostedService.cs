using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Backgroud_Tasks
{
    public class IntervalTaskHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SaveFile, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        public void SaveFile(object state )
        {
            string NmaeFile = "a" + new Random().Next(1000) + ".txt";
            string paht = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", NmaeFile);
            File.Create(paht);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
