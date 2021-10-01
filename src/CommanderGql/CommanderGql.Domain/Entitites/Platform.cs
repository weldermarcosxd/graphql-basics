using CommanderGql.Domain.Common;
using System.Collections.Generic;

namespace CommanderGql.Domain.Entitites
{
    public class Platform : BaseEntity
    {
        public string Name { get; set; }

        public string LicenseKey { get; set; }

        public IList<Command> Commands { get; private set; } = new List<Command>();
    }
}