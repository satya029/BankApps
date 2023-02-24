using Bank.Application.CQRS.Interface;
using Bank.Application.Users.Events;
using Bank.Core.Entities;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;

namespace Bank.Application.UsersAccount.Events
{
    public class NotificationEventHandler : IHandleEvent<MoneyTransferedEvent>, IHandleEvent<UserLogoutEvent>
    {
        private readonly GenericRepository<TblNotifications> _notificationRepository;
        private readonly GenericRepository<UserLogins> _loginRepository;

        public NotificationEventHandler(GenericRepository<TblNotifications> notificationRepository, GenericRepository<UserLogins> loginRepository)
        {
            _notificationRepository = notificationRepository;
            _loginRepository = loginRepository;
        }
        public void Handle(MoneyTransferedEvent @event)
        {
            var notification = new TblNotifications
            {
                IsDisplayed = false,
                Login = _loginRepository.GetById(@event.AccountId),
                Message = string.Format($"{@event.Amount} transfered: {@event.OccurredOn}.")
            };
            _notificationRepository.Create(notification);
        }

        public void Handle(UserLogoutEvent @event)
        {
            var notification = new TblNotifications
            {
                IsDisplayed = false,
                Login = _loginRepository.GetById(@event.UserId),
                Message = string.Format($"User logout: {@event.OccurredOn}.")
            };
            _notificationRepository.Create(notification);
        }
    }
}
