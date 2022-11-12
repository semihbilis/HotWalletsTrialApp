namespace HotWalletsTrialApp.Models;
public class Notification
{
  #region Constructor
  public Notification(string title, string pathQuitCommand, string message)
  {
    Title = title ?? string.Empty;
    PathQuitCommand = pathQuitCommand ?? string.Empty;
    Message = message ?? string.Empty;
  }
  #endregion

  #region Property
  public string Title { get; set; }
  public string Message { get; set; }
  public string PathQuitCommand { get; set; }
  #endregion
}