using Bank.Application.CQRS.Interface;
using System.ComponentModel.DataAnnotations;

namespace Bank.Application.UsersAccount.Queries
{
    public class GetAccountQueryById : IQuery
    {
        [Required]
        public int AccountId { get; set; }
    }
}
