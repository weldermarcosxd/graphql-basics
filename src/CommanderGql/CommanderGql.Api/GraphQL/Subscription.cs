using CommanderGql.Domain.Entitites;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGql.Api.GraphQL
{
    public class Subscription
    {
        [Topic]
        [Subscribe]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}
