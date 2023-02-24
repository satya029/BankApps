using Bank.Core.Entities;

namespace Bank.Infrastructure
{
    public class TblNotifications : IBaseIdentity
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public UserLogins? Login { get; set; }
        public bool IsDisplayed { get; set; }
    }
}
