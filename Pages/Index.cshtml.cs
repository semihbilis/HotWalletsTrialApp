using HotWalletsTrialApp.Common.Helper;
using HotWalletsTrialApp.Models;
using HotWalletsTrialApp.Models.Concrete;
using HotWalletsTrialApp.Models.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotWalletsTrialApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private RepoAccount repoAccount = new RepoAccount();
        private Notification notification = new Notification("Login Page", HelperFilePath.FilePathIndex, "All fields are not empty.");

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public Account LogingAccount = new Account();

        public PartialViewResult OnGetSignUp()
        {
            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial(HelperFilePath.LoginPages.SignUp, LogingAccount);
        }

        public PartialViewResult OnGetSignIn()
        {
            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial(HelperFilePath.LoginPages.SignIn, LogingAccount);
        }

        public IActionResult OnPostSignUp(string firstName, string lastName, string email, string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email))
            {
                notification.Message = "All fields are not empty.";

                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial(HelperFilePath.NotificationPages.ErrorNotification, notification);
            }
            LogingAccount.FirstName = firstName;
            LogingAccount.LastName = lastName;
            LogingAccount.Email = email;
            LogingAccount.Username = username;
            LogingAccount.Password = password;
            Account loginingUser = repoAccount.SignUp(LogingAccount);
            if (loginingUser != null)
            {
                repoAccount.Save();
                return OnGetSignIn();
            }
            else
            {
                notification.Message = "User information incorrect.";

                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial(HelperFilePath.NotificationPages.ErrorNotification, notification);
            }
        }

        public IActionResult OnPostSignIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                notification.Message = "Username and Password are not empty.";

                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial(HelperFilePath.NotificationPages.ErrorNotification, notification);
            }
            LogingAccount.Username = username;
            LogingAccount.Password = password;
            Account loginingUser = repoAccount.SignIn(LogingAccount);
            if (loginingUser != null)
            {
                Program.CurrentAccount = loginingUser;
                return RedirectToPage("Main");
            }
            else
            {
                notification.Message = "User information incorrect.";

                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial(HelperFilePath.NotificationPages.ErrorNotification, notification);
            }
        }

        public PartialViewResult OnGetNotificationQuit()
        {
            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial(HelperFilePath.NotificationPages.EmptyNotification);
        }
    }
}