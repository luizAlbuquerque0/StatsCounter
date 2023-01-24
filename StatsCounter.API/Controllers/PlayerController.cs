using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatsCounter.Application.Commands.CreatePlayer;
using StatsCounter.Application.Commands.LoginUser;
using StatsCounter.Application.Queries.GetPlayerStats;

namespace StatsCounter.API.Controllers
{
    [Route("api/players")]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerCommand comand)
        {
            var id = await _mediator.Send(comand);

            return CreatedAtAction(nameof(GetById), new { id = id }, comand);
        }

        [HttpPut("login")]
        [AllowAnonymous]

        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
           var loginViewModel =  await _mediator.Send(command);

            if (loginViewModel == null) return BadRequest();

            return Ok(loginViewModel);
        }
    }
}
