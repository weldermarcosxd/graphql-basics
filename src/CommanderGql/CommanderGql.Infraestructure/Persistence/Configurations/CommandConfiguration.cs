using CommanderGql.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGql.Infraestructure.Persistence.Configurations
{
    public class CommandConfiguration : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.Property(o => o.HowTo)
                .HasMaxLength(255);

            builder.Property(x => x.CommandLine)
                .HasMaxLength(255);

            builder.HasOne(x => x.Platform)
                .WithMany(x => x.Commands)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}