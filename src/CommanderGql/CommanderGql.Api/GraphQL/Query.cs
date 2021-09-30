using CommanderGql.Application.GraphQL;
using CommanderGql.Domain.Entitites;
using CommanderGql.Infraestructure.Persistence;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace CommanderGql.Api.GraphQL
{
    public class Query : IQuery<AppDbContext>
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}