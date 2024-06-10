using Microsoft.AspNetCore.Mvc;
using Leaderboard.Services;

namespace Leaderboard.Controllers
{
    [Route("leaderboard")]
    [ApiController]
    public sealed class DateTimeController : ControllerBase
    {
        private readonly DateTimeService _dateTimeService;

        public DateTimeController(DateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        [HttpGet("datetime")]
        public async Task<string> Get()
        {
            return await new Task<string>(_dateTimeService.GetDateTime);
        }
    }
}
