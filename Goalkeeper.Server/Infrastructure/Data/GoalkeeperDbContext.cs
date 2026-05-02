using Goalkeeper.Server.Core;
using Microsoft.EntityFrameworkCore;

namespace Goalkeeper.Server.Infrastructure.Data;

public class GoalkeeperDbContext(DbContextOptions<GoalkeeperDbContext> options) : DbContext(options)
{
    public DbSet<Team> Teams => Set<Team>();
}
