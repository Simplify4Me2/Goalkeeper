using System;

namespace GoalKeeper.Stats.Domain.Core
{
    public abstract class AggregateBase : IAggregate<Guid>
    {
        public const int NewAggregateVersion = -1;

        private int _version = NewAggregateVersion;

        public Guid Id { get; protected set; }

        protected void RaiseEvent<TEvent>(TEvent @event)
            where TEvent : DomainEventBase
        {

        }
    }
}
