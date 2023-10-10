using DIExample;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
    //{
    //    internal class Worker:BackgroundService
    //    {

    //            private readonly MessageWriter _messageWriter = new MessageWriter();

    //            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //            {
    //                while (!stoppingToken.IsCancellationRequested)
    //                {
    //                    _messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
    //                    await Task.Delay(1000, stoppingToken);
    //                }
    //            }

    //    }



    //public sealed class Worker : BackgroundService
    //{
    //    private readonly IMessageWriter _messageWriter;

    //    public Worker(IMessageWriter messageWriter) =>
    //        _messageWriter = messageWriter;

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        while (!stoppingToken.IsCancellationRequested)
    //        {
    //            _messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
    //            await Task.Delay(1_000, stoppingToken);
    //        }
    //    }
    //}


    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageWriter _messageWriter;

        public Worker(ILogger<Worker> logger, IMessageWriter messageWriter)
        {
            _logger = logger;
            _messageWriter = messageWriter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
                await Task.Delay(1_000, stoppingToken);
            }
        }
    }
}
