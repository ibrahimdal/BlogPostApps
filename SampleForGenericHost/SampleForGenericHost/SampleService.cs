using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForGenericHost
{
    public class SampleService : IHostedService, IDisposable
    {
        private readonly ILogger<SampleService> _logger;
        private Timer _timer;

        public SampleService(
            ILogger<SampleService> logger
            )
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Service is working.");
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
