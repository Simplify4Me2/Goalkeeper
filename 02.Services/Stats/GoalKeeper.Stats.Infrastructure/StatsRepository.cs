using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using GoalKeeper.Stats.Infrastructure.EventStore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure
{
    public class StatsRepository : IStatsRepository
    {
        private readonly IEventStore _eventStore;

        public StatsRepository(IEventStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public async Task<Ranking> GetRanking(CancellationToken cancellationToken)
        {
            var ranking = _eventStore.AggregateStream<Ranking>(1);

            //Ranking ranking = new Ranking
            //{
            //    Id = 1,
            //    Name = "Jupiler Pro League",
            //    Teams = new List<string> { "RSC Anderlecht", "Antwerp", "KRC Genk", "Club Brugge" }
            //};

            //var foo = new EventSourcingRepository();
            //await foo.SaveAsync(new Guid());

            return ranking;
        }
    }
}
