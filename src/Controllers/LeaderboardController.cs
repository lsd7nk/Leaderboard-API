﻿using Microsoft.AspNetCore.Mvc;
using Leaderboard.Repositories;
using Leaderboard.Models;

namespace Leaderboard.Controllers
{
    [ApiController]
    [Route("leaderboard")]
    public sealed class LeaderboardController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public LeaderboardController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<User?> Get(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _repository.GetAsync(id);

            if (user == null)
                return BadRequest();

            await _repository.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User entity)
        {
            await _repository.AddAsync(entity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User entity)
        {
            var user = await _repository.GetAsync(entity.Id);

            if (user == null)
                return BadRequest();

            user = entity;

            await _repository.UpdateAsync(user);
            return Ok();
        }
    }
}