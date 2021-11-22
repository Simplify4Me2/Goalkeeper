using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Application.Ports
{
    public interface IMatchRepository
    {
        Task<Domain.Match[]> Get(int matchday);

        Task Save(Domain.Match[] matches);
    }
}
