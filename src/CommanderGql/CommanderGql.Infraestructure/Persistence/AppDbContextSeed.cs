using CommanderGql.Application.Persistence;
using CommanderGql.Domain.Entitites;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderGql.Infraestructure.Persistence
{
    public static class AppDbContextSeed
    {
        public static async Task SeedSampleDataAsync(IAppDbContext context, ILogger logger)
        {
            if (!context.Platforms.Any())
            {
                context.Platforms.AddRange(
                    new Platform { Name = "Windows", LicenseKey = "987asd987asd98as7d9a8sd7as" },
                    new Platform { Name = "Osx", LicenseKey = "587asd987asd98as7d9a8sd7as" },
                    new Platform { Name = "Linux", LicenseKey = "" }
                );
            };

            if (!context.Commands.Any())
            {
                await context.SaveChangesAsync();

                var windows = context.Platforms.FirstOrDefault(x => x.Name == "Windows");
                var osx = context.Platforms.FirstOrDefault(x => x.Name == "Osx");
                var linux = context.Platforms.FirstOrDefault(x => x.Name == "Linux");
                context.Commands.AddRange(
                    new Command { HowTo = "ip configuration", PlatformId = windows.Id, CommandLine = "ipconfig" },
                    new Command { HowTo = "show history", PlatformId = osx.Id, CommandLine = "history" },
                    new Command { HowTo = "list files in directory", PlatformId = linux.Id, CommandLine = "ls" }
                );
            };

            await context.SaveChangesAsync();
        }
    }
}