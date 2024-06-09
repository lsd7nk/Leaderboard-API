namespace Leaderboard.Middleware
{
    public abstract class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public virtual async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
        }
    }
}
