using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CommanderGql.Infraestructure.Persistence
{
    public static class Migrator
    {
        public async static Task MigrateAsync(this IHost host, ILogger logger)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();

                if (context.Database.IsSqlServer())
                    context.Database.Migrate();

                await AppDbContextSeed.SeedSampleDataAsync(context, logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                throw;
            }
        }
    }
}