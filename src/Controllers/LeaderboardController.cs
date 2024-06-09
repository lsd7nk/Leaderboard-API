using Microsoft.AspNetCore.Mvc;
using Leaderboard.Repositories;
using Leaderboard.Models;

namespace Leaderboard.Controllers
{
    [Route("leaderboard")]
    [ApiController]
    public sealed class LeaderboardController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public LeaderboardController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet("users")]
        public async Task<IEnumerable<User>> Get()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("user/{id}")]
        public async Task<User?> Get(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        [HttpPost("users/delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _repository.GetAsync(id);

            if (user == null)
                return BadRequest("User not found");

            await _repository.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("users/add")]
        public async Task Post([FromBody] User entity)
        {
            await _repository.AddAsync(entity);
        }

        [HttpPost("users/update")]
        public async Task<IActionResult> Put([FromBody] User entity)
        {
            var user = await _repository.GetAsync(entity.Id);

            if (user == null)
                return BadRequest("User not found");

            user = entity;

            await _repository.UpdateAsync(user);
            return Ok();
        }
    }
}
