namespace GoalKeeper.Stats.Domain.Core
{
    // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
