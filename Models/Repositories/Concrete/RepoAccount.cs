using HotWalletsTrialApp.Models.Concrete;

namespace HotWalletsTrialApp.Models.Repositories.Concrete
{
    public class RepoAccount : Repository<Account>
    {
        public Account SignIn(Account logingAccount)
        {
            return Get(a => a.Password == logingAccount.Password && a.Username == logingAccount.Username);
        }

        public Account SignUp(Account logingAccount)
        {
            Account responseAccount = Get(a => (a.Password == logingAccount.Password && (a.Username == logingAccount.Username || a.Email == logingAccount.Email))
                                            || (a.FirstName == logingAccount.FirstName && a.LastName == logingAccount.LastName));
            if (responseAccount == null)
            {
                return Add(new Account()
                {
                    FirstName = logingAccount.FirstName,
                    LastName = logingAccount.LastName,
                    Email = logingAccount.Email,
                    Username = logingAccount.Username,
                    Password = logingAccount.Password
                });
            }
            else
                return null;
        }
    }
}
