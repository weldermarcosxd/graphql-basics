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

            await context.SaveChangesAsync();
        }
    }
}