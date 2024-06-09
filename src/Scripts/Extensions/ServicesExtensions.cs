using Leaderboard.Contexts;
using Leaderboard.Services;

namespace Leaderboard.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDateTimeService(this IServiceCollection services)
        {
            services.AddTransient<DateTimeService>();
        }

        public static void AddLeaderboardContext(this IServiceCollection services)
        {
            services.AddDbContext<LeaderboardContext>();
        }
    }
}
