using CommanderGql.Domain.Entitites;
using CommanderGql.Infraestructure.Persistence;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace CommanderGql.Api.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}