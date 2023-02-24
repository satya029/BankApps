using Bank.Application.CQRS.Interface;
using Bank.Application.Models;
using Bank.Application.Users.Queries;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;

namespace Bank.Application.Users.QueryHandlers
{
    public class GetNotificationForUserIdQueryHandler : IHandleQuery<GetNotificationForUserIdQuery, IEnumerable<NotificationModel>>
    {
        private readonly GenericRepository<TblNotifications> _notificationRepository;

        public GetNotificationForUserIdQueryHandler(GenericRepository<TblNotifications> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public IEnumerable<NotificationModel> Handle(GetNotificationForUserIdQuery query)
        {
            var notifications = _notificationRepository.GetAll().Where(x => x.Login?.Id == query.UserId && x.IsDisplayed == false);

            //TODO: Set IsDisplayed to false
            //_notificationRepository.Update()

            return notifications.Select(x => new NotificationModel
            {
                Message = x.Message
            });
        }
    }
}
