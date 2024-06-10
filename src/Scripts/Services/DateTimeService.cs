namespace Leaderboard.Services
{
    public sealed class DateTimeService
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
