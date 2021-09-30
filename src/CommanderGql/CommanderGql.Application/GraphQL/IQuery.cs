using CommanderGql.Application.Persistence;
using CommanderGql.Domain.Entitites;
using System.Linq;

namespace CommanderGql.Application.GraphQL
{
    public interface IQuery<T>
        where T : IAppDbContext
    {
        IQueryable<Platform> GetPlatform(T context);
    }
}