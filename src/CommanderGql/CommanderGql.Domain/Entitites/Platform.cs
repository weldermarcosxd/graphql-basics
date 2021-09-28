using CommanderGql.Domain.Common;

namespace CommanderGql.Domain.Entitites
{
    public class Platform : BaseEntity
    {
        public string Name { get; set; }

        public string LicenseKey { get; set; }
    }
}