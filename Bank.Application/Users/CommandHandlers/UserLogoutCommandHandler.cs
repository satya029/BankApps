using Bank.Application.CQRS.Interface;
using Bank.Application.Users.Commands;
using Bank.Application.Users.Events;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;

namespace Bank.Application.Users.CommandHandlers
{
    public class UserLogoutCommandHandler : IHandleCommand<UserLogoutCommand>
    {
        private readonly IEventsBus _eventBus;
        private readonly GenericRepository<TblInvalidKeys> _invalidKeysRepository;

        public UserLogoutCommandHandler(IEventsBus eventBus, GenericRepository<TblInvalidKeys> invalidKeysRepository)
        {
            _eventBus = eventBus;
            _invalidKeysRepository = invalidKeysRepository;
        }

        public void Handle(UserLogoutCommand command)
        {
            var invalidKey = new TblInvalidKeys
            {
                Key = command.Key,
                UserId = command.UserId
            };

            _invalidKeysRepository.Create(invalidKey);

            _eventBus.Publish(new UserLogoutEvent { UserId = command.UserId });
        }
    }
}
