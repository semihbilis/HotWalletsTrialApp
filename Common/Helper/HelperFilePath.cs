namespace HotWalletsTrialApp.Common.Helper;
internal static class HelperFilePath
{
  internal static string FileIndex = Consts.FileIndex;
  internal static string FileMain = Consts.FileMain;

  internal static FolderNotificationPages NotificationPages = new(Consts.FolderNotificationPages);
  internal static FolderLoginPages LoginPages = new(Consts.FolderLoginPages);
  internal static FolderWalletPages WalletPages = new(Consts.FolderWalletPages);
}

internal class FolderLoginPages : BaseFolderModel
{
  #region Constructor
  public FolderLoginPages(string folderPath) : base(folderPath) { }
  #endregion

  #region Property
  internal string SignIn => GetPath(Consts.FileSignIn);
  internal string SignUp => GetPath(Consts.FileSignUp);
  #endregion
}

internal class FolderNotificationPages : BaseFolderModel
{
  #region Constructor
  public FolderNotificationPages(string folderPath) : base(folderPath) { }
  #endregion

  #region Property
  internal string EmptyNotification => GetPath(Consts.FileEmptyNotification);
  internal string ErrorNotification => GetPath(Consts.FileErrorNotification);
  internal string WarningNotification => GetPath(Consts.FileWarningNotification);
  internal string SuccessNotification => GetPath(Consts.FileSuccessNotification);
  #endregion
}

internal class FolderWalletPages : BaseFolderModel
{
  #region Constructor
  public FolderWalletPages(string folderPath) : base(folderPath) { }
  #endregion

  #region Property
  internal string ViewWallet => GetPath(Consts.FileViewWallet);
  internal string ListWallet => GetPath(Consts.FileListWallet);
  #endregion
}

internal abstract class BaseFolderModel
{
  #region Constructor
  public BaseFolderModel(string folderPath)
  {
    Path = folderPath;
  }
  #endregion

  #region Property
  internal readonly string Path;
  #endregion

  #region Method
  protected string GetPath(string fileName) => Path + "/" + fileName;
  #endregion
}