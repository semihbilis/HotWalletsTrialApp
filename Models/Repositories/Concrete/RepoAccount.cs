using HotWalletsTrialApp.Models.Concrete;

namespace HotWalletsTrialApp.Models.Repositories.Concrete
{
    public class RepoAccount : Repository<Account>
    {
        public Account LogIn(string email, string password)
        {
            return Get(a => a.Email == email && a.Password == password);
        }
    }
}
