using GoalKeeper.DataCollector.Application.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Infrastructure.Repositories
{
    public class SQLRepository : IMatchRepository
    {
        private readonly MatchDbContext _dbContext;

        public SQLRepository(MatchDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _dbContext = dbContext;
        }

        public async Task<Domain.Match[]> Get(int matchday)
        {
            var query = from match in _dbContext.Matches
                        where match.Matchday == matchday
                        select match;

            return await query.ToArrayAsync();
        }

        public Task Save(Domain.Match[] matches)
        {
            _dbContext.Matches.AddRangeAsync(matches);
            return _dbContext.SaveChangesAsync();
        }
    }
}
