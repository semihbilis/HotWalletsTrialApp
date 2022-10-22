using HotWalletsTrialApp.Models.Concrete;

namespace HotWalletsTrialApp.Models.Repositories.Concrete
{
    public class RepoAccount : Repository<Account>
    {
        public Account LogIn(string username, string password)
        {
            return Get(a => a.Password == password && (a.Email == username || a.Username == username));
        }
    }
}
