using Bank.Application.CQRS.Interface;
using System.ComponentModel.DataAnnotations;

namespace Bank.Application.Users.Commands
{
    public class UserLogoutCommand : ICommand
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string? Key { get; set; }
    }
}
