namespace Bank.Application.Models
{
    public class BankAccountModel
    {
        public int Id { get; set; }
        public string? AccountNo { get; set; }
        public decimal Balance { get; set; }
    }
}
