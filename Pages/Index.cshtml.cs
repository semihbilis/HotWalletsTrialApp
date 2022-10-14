﻿using HotWalletsTrialApp.Models.Concrete;
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
        private const string PathValidationPages = "ValidationPages/";
        private RepoAccount repoAccount = new RepoAccount();

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return Partial(PathValidationPages + "FailedUsernamePassword");

            Account loginAccount = repoAccount.LogIn(email, password);
            if (loginAccount != null)
            {
                Program.CurrentAccount = loginAccount;
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