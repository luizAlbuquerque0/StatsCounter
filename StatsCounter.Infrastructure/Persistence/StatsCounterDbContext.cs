using Microsoft.EntityFrameworkCore;
using StatsCounter.Core.Entities;
using System.Reflection;

namespace StatsCounter.Infrastructure.Persistence
{
    public class StatsCounterDbContext : DbContext
    {
        public StatsCounterDbContext(DbContextOptions<StatsCounterDbContext> options) : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
