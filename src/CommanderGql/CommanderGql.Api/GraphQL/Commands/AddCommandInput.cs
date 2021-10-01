using System;

namespace CommanderGql.Api.GraphQL.Commands
{
    public record AddCommandInput(string HowTo, string CommandLine, Guid PlatformId);
}