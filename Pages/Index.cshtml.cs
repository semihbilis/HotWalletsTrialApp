using HotWalletsTrialApp.Models.Concrete;
using HotWalletsTrialApp.Models.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotWalletsTrialApp.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<IndexModel> _logger;
        public readonly string PathValidationPages = "ValidationPages";
        private RepoAccount repoAccount = new RepoAccount();

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Partial(PathValidationPages + "/FailedUsernamePassword");
            }

            Account loginAccount = repoAccount.LogIn(username, password);
            if (loginAccount != null)
            {
                Program.CurrentAccount = loginAccount;
                return RedirectToPage("Main");
            }
            else
                return Partial(PathValidationPages + "/FailedLogin");
        }

        public PartialViewResult OnGetNotificationQuit()
        {
            return Partial(PathValidationPages + "/EmptyNotification");
        }
    }
}