using Bank.Core.Entities;

namespace Bank.Infrastructure
{
    public class TblInvalidKeys : IBaseIdentity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Key { get; set; }
    }
}
