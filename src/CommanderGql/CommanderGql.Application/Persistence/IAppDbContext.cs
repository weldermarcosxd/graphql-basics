using CommanderGql.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace CommanderGql.Application.Persistence
{
    public interface IAppDbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        public DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}