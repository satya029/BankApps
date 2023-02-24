namespace Bank.Application.CQRS.Interface
{
    public interface IEventsBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
