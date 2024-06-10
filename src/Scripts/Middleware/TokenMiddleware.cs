namespace Leaderboard.Middleware
{
    public sealed class TokenMiddleware : Middleware
    {
        private readonly string _token;
        private const string QUERY_KEY = "token";

        public TokenMiddleware(RequestDelegate next, string token) : base(next)
        {
            _token = token;
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            var query = context.Request.Query;

            if (!query.ContainsKey(QUERY_KEY) || !ValidateToken(query[QUERY_KEY]))
            {
                context.Response.StatusCode = 403;
                return;
            }

            await base.InvokeAsync(context);
        }

        private bool ValidateToken(string? token)
        {
            return !string.IsNullOrEmpty(token) && token == _token;
        }
    }
}
