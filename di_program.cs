using DIExample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DIExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);


            builder.Services.AddHostedService<Worker>();
            //builder.Services.AddSingleton<IMessageWriter, MessageWriter>();
            builder.Services.AddSingleton<IMessageWriter, LoggingMessageWriter>();

            using IHost host = builder.Build();

            host.Run();
        }
    }
}
