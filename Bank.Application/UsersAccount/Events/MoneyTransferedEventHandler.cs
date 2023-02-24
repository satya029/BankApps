using Bank.Application.CQRS.Interface;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;
using Newtonsoft.Json;

namespace Bank.Application.UsersAccount.Events
{
    public class MoneyTransferedEventHandler : IHandleEvent<MoneyTransferedEvent>
    {
        private readonly GenericRepository<TblEvents> _eventRepository;

        public MoneyTransferedEventHandler(GenericRepository<TblEvents> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Handle(MoneyTransferedEvent @event)
        {
            var serializedEvent = JsonConvert.SerializeObject(@event);

            _eventRepository.Create(new TblEvents { JSON = serializedEvent });
        }
    }
}
