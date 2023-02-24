using Bank.Application.CQRS.Events;

namespace Bank.Application.Users.Events
{
    public class UserLogoutEvent : DomainEventBase
    {
        public int UserId { get; set; }
    }
}
