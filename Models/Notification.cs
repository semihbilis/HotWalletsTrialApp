namespace HotWalletsTrialApp.Models
{
    public class Notification
    {
        public Notification() { }
        public Notification(string? title, string pathQuitCommand, string message) : this()
        {
            Title = title ?? string.Empty;
            PathQuitCommand = pathQuitCommand ?? string.Empty;
            Message = message ?? string.Empty;
        }
        public string Title { get; set; }
        public string Message { get; set; }
        public string PathQuitCommand { get; set; }
    }
}
