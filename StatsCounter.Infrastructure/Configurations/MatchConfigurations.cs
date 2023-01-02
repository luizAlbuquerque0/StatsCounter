using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatsCounter.Core.Entities;

namespace StatsCounter.Infrastructure.Configurations
{
    internal class MatchConfigurations : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .HasOne(m => m.Player)
                .WithMany(p => p.Matches)
                .HasForeignKey(m => m.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
