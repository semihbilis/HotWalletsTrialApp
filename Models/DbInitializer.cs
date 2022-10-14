using HotWalletsTrialApp.Models.Concrete;
using HotWalletsTrialApp.Models.DBContext.EntityFramework;

namespace HotWalletsTrialApp.Models
{
    public static class DbInitializer
    {
        public static void Initialize(EfContext context)
        {
            if (context.Account.Any())
            {
                return;
            }

            context.Account.Add(new Account
            {
                Email = "admin@admin",
                Password = "admin",
                FirstName = "admin",
                LastName = "admin",
                CreateAccountId = 1
            });
            context.SaveChanges();
        }
    }
}
