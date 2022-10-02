using System.Diagnostics;
using HotWalletsTrialApp.Models.DataAccount;
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
        private const string PathValidationPages = "ValidationPages/";
        private RepoAccount repoAccount = new RepoAccount();

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return Partial(PathValidationPages + "FailedUsernamePassword");

            Account signinAccount = repoAccount.Sign(username, password);
            if (signinAccount != null)
            {
                Program.CurrentAccount = signinAccount;
                return RedirectToPage("Main");
            }
            else
                return Partial(PathValidationPages + "FailedLogin");
        }

        public PartialViewResult OnGetNotificationQuit()
        {
            return Partial(PathValidationPages + "EmptyNotification");
        }
    }
}