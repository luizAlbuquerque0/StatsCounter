using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatsCounter.Application.Commands.CreateMatch;
using StatsCounter.Application.Commands.DeleteMatch;
using StatsCounter.Application.Commands.UpdateMatch;
using StatsCounter.Application.Queries.GetAllPlayerMatches;
using StatsCounter.Application.Queries.GetMatchById;

namespace StatsCounter.API.Controllers
{
    [Route("api/matchs")]
    [Authorize]
    public class MatchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetMatchByIdQuery(id);

            var match = await _mediator.Send(query);
            if (match == null) return NotFound();

            return Ok(match);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] CreateMatchCommand command)
        {
            var id = await _mediator.Send(command);
            if(id == null) return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatch([FromBody] UpdateMatchCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var command = new DeleteMatchCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("player/{id}")]
        public async Task<IActionResult> GetAllPlayerMatches(int id)
        {
            var query = new GetAllPlayerMatchesQuery(id);

            var matchs = await _mediator.Send(query);
            if (matchs == null) return NotFound();

            return Ok(matchs);
        }


    }
}
