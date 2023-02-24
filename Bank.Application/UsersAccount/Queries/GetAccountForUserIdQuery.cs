using Bank.Application.CQRS.Interface;
using System.ComponentModel.DataAnnotations;

namespace Bank.Application.UsersAccount.Queries
{
    public class GetAccountForUserIdQuery : IQuery
    {
        [Required]
        public int UserId { get; set; }
    }
}
