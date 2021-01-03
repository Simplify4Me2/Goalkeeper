using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IEventSourcingRepository<T>
    {
        Task<T> GetByIdAsync();

        Task SaveAsync(T aggregate);
    }
}
