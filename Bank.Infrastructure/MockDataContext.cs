using Bank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Bank.Infrastructure
{
    public class MockDataContext : IDisposable
    {
        public IEnumerable<UserLogins>? Logins { get; set; }
        public IEnumerable<BankAccounts>? BankAccounts { get; set; }
        public IEnumerable<TblNotifications>? Notifications { set; get; }
        public IEnumerable<TblInvalidKeys>? InvalidKeys { set; get; }
        public IEnumerable<TblEvents>? Events { set; get; }

        public MockDataContext() 
        {
            MockData();
        }

        private void MockData()
        {
            Logins = new List<UserLogins>
            {
                new UserLogins
                {
                    Id= 1,
                    BankAccounts = null,
                    Login = "satya".ToUpper(),
                    PreDefinedAccounts = new List<BankAccounts>()
                },
                new UserLogins
                {
                    Id= 2,
                    BankAccounts = null,
                    Login = "robot".ToUpper(),
                    PreDefinedAccounts = new List<BankAccounts>()
                }
            };

            BankAccounts = new List<BankAccounts>
            {
                new BankAccounts
                {
                    Id = 1,
                    AccountNo = "SBI012121020101",
                    Balance = 500,
                    Login = Logins.FirstOrDefault(x=>x.Login == "satya".ToUpper())
                },
                new BankAccounts
                {
                    Id = 2,
                    AccountNo = "SBI012121020102",
                    Balance = 655,
                    Login = Logins.FirstOrDefault(x=>x.Login == "satya".ToUpper())
                },
                new BankAccounts
                {
                    Id = 3,
                    AccountNo = "SBI012121020103",
                    Balance = 1000,
                    Login = Logins.FirstOrDefault(x=>x.Login == "robot".ToUpper())
                }
            };

            Logins.FirstOrDefault(predicate: x => x.Login == "satya".ToUpper()).PreDefinedAccounts.Add(
               BankAccounts.FirstOrDefault(x => x.Id == 3)
                );

            Logins.FirstOrDefault(x => x.Login == "robot".ToUpper()).PreDefinedAccounts.Add(
               BankAccounts.FirstOrDefault(x => x.Id == 2)
                );


            Notifications = new List<TblNotifications>();
            InvalidKeys = new List<TblInvalidKeys>();
            Events = new List<TblEvents>();
        }

        public void Dispose()
        {
        }
    }
}
