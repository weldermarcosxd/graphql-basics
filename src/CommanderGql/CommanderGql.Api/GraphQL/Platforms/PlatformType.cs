using CommanderGql.Domain.Entitites;
using CommanderGql.Infraestructure.Persistence;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CommanderGql.Api.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor
                .Description("Represents any software or service that has command line interface.");

            descriptor
                .Field(x => x.LicenseKey)
                .Ignore();

            descriptor
                .Field(x => x.Name)
                .Description("Name of the platform");

            descriptor
                .Field(x => x.Commands)
                .ResolveWith<Resolvers>(x => x.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("List of valid commands form platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(x => x.PlatformId == platform.Id);
            }
        }
    }
}