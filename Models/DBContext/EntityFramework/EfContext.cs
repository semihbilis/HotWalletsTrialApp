using HotWalletsTrialApp.Models.DataAccount;
using HotWalletsTrialApp.Models.DataAuthorization;
using HotWalletsTrialApp.Models.DataCategory;
using HotWalletsTrialApp.Models.DataWallet;
using HotWalletsTrialApp.Models.DataWalletTransaction;
using System.Data.Entity;

namespace HotWalletsTrialApp.DatabaseContext.EntityFramework
{
    public class EfContext : DbContext
    {
        public EfContext() : base("HotWallets")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasOptional<Wallet>(a => a.Wallet)
                .WithRequired(w => w.Account);
            modelBuilder.Entity<Account>()
                .HasMany<Authorization>(a => a.AuthorizationList)
                .WithRequired(aut => aut.Account);

            modelBuilder.Entity<Authorization>()
                .HasRequired<Account>(aut => aut.Account)
                .WithMany(a => a.AuthorizationList);
            modelBuilder.Entity<Authorization>()
                .HasRequired<Wallet>(aut=>aut.Wallet)
                .WithMany(w=>w.AuthorizationList);

            modelBuilder.Entity<Wallet>()
                .HasRequired<Account>(w => w.Account)
                .WithOptional(a => a.Wallet);
            modelBuilder.Entity<Wallet>()
                .HasMany(w=>w.AuthorizationList)
                .WithRequired(aut=>aut.Wallet);
            modelBuilder.Entity<Wallet>()
                .HasMany<WalletTransaction>(w=>w.TransactionList)
                .WithRequired(wt=>wt.Wallet);

            modelBuilder.Entity<WalletTransaction>()
                .HasRequired<Wallet>(wt => wt.Wallet)
                .WithMany(w => w.TransactionList);
            modelBuilder.Entity<WalletTransaction>()
                .HasRequired<Category>(wt => wt.Category)
                .WithMany(c => c.WalletTransactionList);

            modelBuilder.Entity<Category>()
                .HasMany<WalletTransaction>(c => c.WalletTransactionList)
                .WithRequired(wt => wt.Category);
        }
    }
}
