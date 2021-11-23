using GoalKeeper.DataCollector.Application.Ports;
using GoalKeeper.DataCollector.Domain;
using System;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Infrastructure.Repositories
{
    public class SQLRepository : IMatchRepository
    {
        public Task<Match[]> Get(int matchday)
        {
            throw new NotImplementedException();
        }

        public Task Save(Match[] matches)
        {
            throw new NotImplementedException();
        }
    }
}
