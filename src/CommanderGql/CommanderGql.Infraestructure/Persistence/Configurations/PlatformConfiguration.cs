using CommanderGql.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGql.Infraestructure.Persistence.Configurations
{
    public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.Property(o => o.Name)
                .HasMaxLength(255);

            builder.Property(x => x.LicenseKey)
                .HasMaxLength(255);

            builder.HasMany(x => x.Commands)
                .WithOne(x => x.Platform)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}