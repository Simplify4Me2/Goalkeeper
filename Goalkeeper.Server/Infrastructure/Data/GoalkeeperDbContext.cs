using Goalkeeper.Server.Core.Entities;

namespace Goalkeeper.Server.Infrastructure.Data;

public class GoalkeeperDbContext(DbContextOptions<GoalkeeperDbContext> options) : DbContext(options)
{
    public DbSet<Team> Teams => Set<Team>();
}
