using System;

namespace Bank.Application.CQRS.Interface
{
    public interface IEvent
    {
        DateTime OccurredOn { get; }
    }
}
