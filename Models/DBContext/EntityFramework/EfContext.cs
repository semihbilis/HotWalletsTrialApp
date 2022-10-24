using HotWalletsTrialApp.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotWalletsTrialApp.Models.DBContext.EntityFramework
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions options) : base(options) { }
        public EfContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("HotWalletsDbString"));
            }
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<WalletAuthorization> WalletAuthorization { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<WalletTransaction> WalletTransaction { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.Wallet).WithOne(w => w.Account).HasForeignKey<Wallet>(s => s.AccountId);
            modelBuilder.Entity<Account>().HasMany(a => a.AuthorizationList).WithOne(aut => aut.Account).HasForeignKey(s => s.AccountId);

            modelBuilder.Entity<WalletAuthorization>().HasOne(aut => aut.Account).WithMany(a => a.AuthorizationList).HasForeignKey(s => s.AccountId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<WalletAuthorization>().HasOne(aut => aut.Wallet).WithMany(w => w.AuthorizationList).HasForeignKey(s => s.WalletId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Wallet>().HasOne(w => w.Account).WithOne(a => a.Wallet).HasForeignKey<Wallet>(s => s.AccountId);
            modelBuilder.Entity<Wallet>().HasMany(w => w.AuthorizationList).WithOne(aut => aut.Wallet).HasForeignKey(s => s.WalletId);
            modelBuilder.Entity<Wallet>().HasMany(w => w.TransactionList).WithOne(wt => wt.Wallet).HasForeignKey(s => s.WalletId);

            modelBuilder.Entity<WalletTransaction>().HasOne(wt => wt.Wallet).WithMany(w => w.TransactionList).HasForeignKey(s => s.WalletId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<WalletTransaction>().HasOne(wt => wt.Category).WithMany(c => c.WalletTransactionList).HasForeignKey(s => s.CategoryId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasMany(c => c.WalletTransactionList).WithOne(wt => wt.Category).HasForeignKey(s => s.CategoryId);
        }
    }
}
