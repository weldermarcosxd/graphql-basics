using CommanderGql.Application.Persistence;
using CommanderGql.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CommanderGql.Infraestructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(IInfraestructureAssemblyMarker)));
        }

        public DbSet<Command> Commands { get; set; }

        public DbSet<Platform> Platforms { get; set; }
    }
}