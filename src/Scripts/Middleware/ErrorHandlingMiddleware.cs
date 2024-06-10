namespace Leaderboard.Middleware
{
    public sealed class ErrorHandlingMiddleware : Middleware
    {
        private const int SUCCESS_STATUS_CODE = 200;
        private const int ACCESS_DENIED_STATUS_CODE = 403;

        public ErrorHandlingMiddleware(RequestDelegate next) : base(next) { }

        public override async Task InvokeAsync(HttpContext context)
        {
            await base.InvokeAsync(context);
            await HandleRequest(context);
        }

        private async Task HandleRequest(HttpContext context)
        {
            var response = context.Response;

            if (response.StatusCode == SUCCESS_STATUS_CODE)
                return;

            await response.WriteAsync(response.StatusCode switch
            {
                ACCESS_DENIED_STATUS_CODE => "Access denied"
            });
        }
    }
}
