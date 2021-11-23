using GoalKeeper.DataCollector.Application.Ports;
using GoalKeeper.DataCollector.Domain;
using System;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Infrastructure.WebScrapers
{
    public class SeleniumWebScraper : IMatchWebScraper
    {
        public Task<Match[]> Get(int matchday)
        {
            throw new NotImplementedException();
        }
    }
}
