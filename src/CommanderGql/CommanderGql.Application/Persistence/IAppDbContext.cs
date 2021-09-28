using CommanderGql.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CommanderGql.Application.Persistence
{
    public interface IAppDbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}