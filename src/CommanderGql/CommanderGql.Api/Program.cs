using CommanderGql.Infraestructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CommanderGql.Api
{
    public static class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Startup>>();
            await host.MigrateAsync(logger);
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}