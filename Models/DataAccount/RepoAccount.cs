using System.Data.Entity;
using System.Diagnostics;

namespace HotWalletsTrialApp.Models.DataAccount
{
    public class RepoAccount : Repository<Account>
    {
        public Account Sign(string username, string password)
        {
            try
            {
                return context.Accounts.Where(a => a.Username == username && a.Password == password).First(); ;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
