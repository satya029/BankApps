using Bank.Core.Entities;

namespace Bank.Infrastructure
{
    public class TblEvents : IBaseIdentity
    {
        public int Id { get; set; }
        public string? JSON { get; set; }
    }
}
