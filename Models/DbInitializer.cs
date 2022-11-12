using HotWalletsTrialApp.Models.Concrete;
using HotWalletsTrialApp.Models.DBContext.EntityFramework;

namespace HotWalletsTrialApp.Models
{
    public class DbInitializer
    {
        public void Initialize(EfContext context)
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
                    if (firstAc != null)
                    {
                        context.Account.Remove(firstAc);
                        context.SaveChanges();
                    }
                }
                return;
            }
            else
            {
                context.Account.Add(firstAccount);
                context.SaveChanges();
            }
        }
    }
}
