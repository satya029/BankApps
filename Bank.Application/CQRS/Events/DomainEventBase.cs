using Bank.Application.CQRS.Interface;

namespace Bank.Application.CQRS.Events
{
    public class DomainEventBase : IEvent
    {
        public DomainEventBase()
        {
            OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}
