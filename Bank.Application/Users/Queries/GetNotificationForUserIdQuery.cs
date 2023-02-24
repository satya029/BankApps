using Bank.Application.CQRS.Interface;
using System.ComponentModel.DataAnnotations;

namespace Bank.Application.Users.Queries
{
    public class GetNotificationForUserIdQuery : IQuery
    {
        [Required]
        public int UserId { get; set; }
    }
}
