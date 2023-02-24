using Bank.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserLogins>? UserLogins { get; set; }
        public DbSet<BankAccounts>? BankAccounts { get; set; }
        public DbSet<TblNotifications>? Notifications { set; get; }
        public DbSet<TblInvalidKeys>? InvalidKeys { set; get; }
        public DbSet<TblEvents>? Events { set; get; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            builder.Entity<BankAccounts>().HasKey(m => m.Id);
            builder.Entity<BankAccounts>().HasOne(m => m.Login).WithMany(x => x.BankAccounts);
            builder.Entity<UserLogins>().HasKey(m => m.Id);
        }
    }
}
