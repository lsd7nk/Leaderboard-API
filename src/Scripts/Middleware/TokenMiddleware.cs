namespace Leaderboard.Middleware
{
    public sealed class TokenMiddleware : Middleware
    {
        private readonly string _token;
        private const string HEADER_KEY = "Token";

        public TokenMiddleware(RequestDelegate next, string token) : base(next)
        {
            _token = token;
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            var query = context.Request.Headers;

            if (!query.ContainsKey(HEADER_KEY) || !ValidateToken(query[HEADER_KEY]))
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
