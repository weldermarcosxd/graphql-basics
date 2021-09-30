using CommanderGql.Domain.Common;
using HotChocolate;
using System.Collections.Generic;

namespace CommanderGql.Domain.Entitites
{
    [GraphQLDescription("Represents any software or service that has command line interface")]
    public class Platform : BaseEntity
    {
        [GraphQLDescription("Name of the platform")]
        public string Name { get; set; }

        [GraphQLDescription("Licence string for platform")]
        public string LicenseKey { get; set; }

        [GraphQLDescription("List of valid commands form platform")]
        public IList<Command> Commands { get; private set; } = new List<Command>();
    }
}