using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatsCounter.Application.Commands.CreatePlayer;
using StatsCounter.Application.Queries.GetPlayerStats;

namespace StatsCounter.API.Controllers
{
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPlayerStatsQuery(id);
            var playerStats = await _mediator.Send(query);

            if (playerStats == null) return NotFound();

            return Ok(playerStats);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerCommand comand)
        {
            var id = await _mediator.Send(comand);

            return CreatedAtAction(nameof(GetById), new { id = id }, comand);
        }
    }
}
