using Bank.Application.CQRS.Interface;
using System.ComponentModel.DataAnnotations;

namespace Bank.Application.Users.Queries
{
    public class LoginQuery : IQuery
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
