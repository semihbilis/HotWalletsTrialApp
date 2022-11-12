using HotWalletsTrialApp.Models.Concrete;

namespace HotWalletsTrialApp.Models.Repositories.Concrete;
public class RepoAccount : Repository<Account>
{
  public Account SignIn(Account logingAccount)
  {
    return Get(a => a.Password == logingAccount.Password && a.Username == logingAccount.Username);
  }

  public Account SignUp(Account logingAccount)
  {
    bool isCreatedAccount = IsCreatedAccount(logingAccount);
    if (!isCreatedAccount)
    {
      return Add(logingAccount);
    }
    else
      return null;
  }

  public bool IsCreatedAccount(Account logingAccount)
  {
    return Any(a => a.Username == logingAccount.Username || a.Email == logingAccount.Email || (a.FirstName == logingAccount.FirstName && a.LastName == logingAccount.LastName));
  }
}