using Microsoft.EntityFrameworkCore;

namespace GoalKeeper.DataCollector.Infrastructure.Repositories
{
    public class MatchDbContext : DbContext
    {
        public MatchDbContext(DbContextOptions<MatchDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Match>()
                .HasKey(match => new { match.Matchday, match.HomeTeamName, match.AwayTeamName });

            modelBuilder.Entity<Domain.Match>()
                .Property(match => match.HomeTeamName)
                .IsRequired();

            modelBuilder.Entity<Domain.Match>()
                .Property(match => match.AwayTeamName)
                .IsRequired();

        }


    }
}
