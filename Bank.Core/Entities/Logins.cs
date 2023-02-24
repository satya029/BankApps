
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Core.Entities
{
    public class UserLogins : IBaseIdentity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password => "demo";
        public virtual List<BankAccounts>? BankAccounts { get; set; }
        public virtual List<BankAccounts>? PreDefinedAccounts { get; set; }
    }
}
