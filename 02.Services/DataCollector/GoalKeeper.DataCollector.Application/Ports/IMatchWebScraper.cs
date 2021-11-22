using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Application.Ports
{
    public interface IMatchWebScraper
    {
        Task<Domain.Match[]> Get(int matchday);
    }
}
