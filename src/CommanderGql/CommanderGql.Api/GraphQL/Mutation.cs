using CommanderGql.Api.GraphQL.Commands;
using CommanderGql.Api.GraphQL.Platforms;
using CommanderGql.Domain.Entitites;
using CommanderGql.Infraestructure.Persistence;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading;
using System.Threading.Tasks;

namespace CommanderGql.Api.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform { Name = input.Name };
            await context.Platforms.AddAsync(platform, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var command = new Command { HowTo = input.HowTo, CommandLine = input.CommandLine, PlatformId = input.PlatformId };
            await context.Commands.AddAsync(command, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new AddCommandPayload(command);
        }
    }
}