using HotWalletsTrialApp.Models.Concrete;
using HotWalletsTrialApp.Models.DBContext.EntityFramework;

namespace HotWalletsTrialApp.Models
{
    public static class DbInitializer
    {
        public static void Initialize(EfContext context)
        {
            Account firstAccount = new Account
            {
                Email = "admin@admin",
                Username = "admin",
                Password = "admin",
                FirstName = "admin",
                LastName = "admin",
            };

            if (context.Account.Any())
            {
                if (context.Account.Count() > 1)
                {
                    Account firstAc = context.Account.First(a => a.Username == firstAccount.Username && a.Password == firstAccount.Password && a.Email == firstAccount.Email && a.FirstName == firstAccount.FirstName && a.LastName == firstAccount.LastName);
                    context.Account.Remove(firstAc);
                }
                return;
            }

            context.Account.Add(firstAccount);
            context.SaveChanges();
        }
    }
}
