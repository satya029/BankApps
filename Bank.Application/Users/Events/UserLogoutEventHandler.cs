using Bank.Application.CQRS.Interface;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;
using Newtonsoft.Json;

namespace Bank.Application.Users.Events
{
    public class UserLogoutEventHandler : IHandleEvent<UserLogoutEvent>
    {
        private readonly GenericRepository<TblEvents> _eventRepository;

        public UserLogoutEventHandler(GenericRepository<TblEvents> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Handle(UserLogoutEvent @event)
        {
            var serializedEvent = JsonConvert.SerializeObject(@event);

            _eventRepository.Create(new TblEvents { JSON = serializedEvent });
        }
    }
}
