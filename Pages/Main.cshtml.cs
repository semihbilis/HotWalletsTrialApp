using HotWalletsTrialApp.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotWalletsTrialApp.Pages;
public class MainModel : PageModel
{
  public void OnGet()
  {
  }

  public PartialViewResult OnGetWallets()
  {
    return Partial(HelperFilePath.WalletPages.ListWallet,
                   Program.CurrentAccount.AuthorizationList?.Where(s=>s.AuthorizationType==Models.AuthorizationType.Read).Select(w=>w.Wallet));
  }
}