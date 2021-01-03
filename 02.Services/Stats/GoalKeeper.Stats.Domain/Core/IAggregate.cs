namespace GoalKeeper.Stats.Domain.Core
{
    public interface IAggregate<T>
    {
        T Id { get; }
    }
}
