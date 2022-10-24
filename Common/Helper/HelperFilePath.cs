namespace HotWalletsTrialApp.Common.Helper
{
    internal static class HelperFilePath
    {
        internal const string FilePathIndex = "Index";
        internal const string FilePathMain = "Main";

        private const string FolderNotificationPagesPath = "NotificationPages";
        internal static FolderNotificationPages NotificationPages = new(FolderNotificationPagesPath);

        private const string FolderLoginPagesPath = "LoginPages";
        internal static FolderLoginPages LoginPages = new(FolderLoginPagesPath);
    }

    internal class FolderLoginPages
    {
        #region FileName
        private const string NameSignIn = "SignIn";
        private const string NameSignUp = "SignUp";
        #endregion

        #region Constructor
        public FolderLoginPages(string folderPath)
        {
            Path = folderPath;
        }
        #endregion

        #region Property
        internal readonly string Path;
        internal string SignIn => GetPath(NameSignIn);
        internal string SignUp => GetPath(NameSignUp);
        #endregion

        #region Method
        private string GetPath(string fileName) => Path + "/" + fileName;
        #endregion
    }

    internal class FolderNotificationPages
    {
        #region FileName
        private const string NameEmptyNotification = "EmptyNotification";
        private const string NameFailedLogin = "FailedLogin";
        private const string NameFailedUsernamePassword = "FailedUsernamePassword";
        private const string NameErrorNotification = "ErrorNotification";
        private const string NameWarningNotification = "WarningNotification";
        private const string NameSuccessNotification = "SuccessNotification";
        #endregion

        #region Constructor
        public FolderNotificationPages(string folderPath)
        {
            Path = folderPath;
        }
        #endregion

        #region Property
        internal readonly string Path;
        internal string EmptyNotification => GetPath(NameEmptyNotification);
        internal string FailedLogin => GetPath(NameFailedLogin);
        internal string FailedUsernamePassword => GetPath(NameFailedUsernamePassword);
        internal string ErrorNotification => GetPath(NameErrorNotification);
        internal string WarningNotification => GetPath(NameWarningNotification);
        internal string SuccessNotification => GetPath(NameSuccessNotification);
        #endregion

        #region Method
        private string GetPath(string fileName) => Path + "/" + fileName;
        #endregion
    }
}
