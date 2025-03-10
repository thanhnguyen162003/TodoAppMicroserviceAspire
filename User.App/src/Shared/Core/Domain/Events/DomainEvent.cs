using Shared.Abstractions.Core.Domain.Events;

namespace Shared.Core.Domain.Events;

// https://github.com/martinothamar/Mediator/issues/138
public abstract record DomainEvent : Event, IDomainEvent
{
    public dynamic AggregateId { get; private set; } = default!;
    public long AggregateSequenceNumber { get; private set; }

    public virtual IDomainEvent WithAggregate(dynamic aggregateId, long version)
    {
        AggregateId = aggregateId;
        AggregateSequenceNumber = version;

        return this;
    }
}