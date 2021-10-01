using CommanderGql.Domain.Entitites;
using CommanderGql.Infraestructure.Persistence;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CommanderGql.Api.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor
                .Description("Represents any executable command");

            descriptor
                .Field(x => x.Platform)
                .ResolveWith<Resolvers>(x => x.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform that which the command belongs");
        }

        private class Resolvers
        {
            public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(x => x.Id == command.PlatformId);
            }
        }
    }
}