using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Core.Entities
{
    public class BankAccounts : IBaseIdentity
    {
        public int Id { get; set; }
        public string? AccountNo { get; set; }
        public decimal? Balance { get; set; }
        public UserLogins? Login { get; set; }
    }
}
