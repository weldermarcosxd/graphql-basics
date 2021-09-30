using CommanderGql.Domain.Common;
using System;

namespace CommanderGql.Domain.Entitites
{
    public class Command : BaseEntity
    {
        public string HowTo { get; set; }

        public string CommandLine { get; set; }

        public Guid PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}