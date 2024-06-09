using Leaderboard.Middleware;

namespace Leaderboard.Extensions
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string? token)
        {
            return builder.UseMiddleware<TokenMiddleware>(token);
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
