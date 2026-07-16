using MediatR;                      
using Microsoft.AspNetCore.Mvc;     
using NoviCode.Commands.Players;    
using NoviCode.Queries.Players;     

namespace NoviCode.Api;

[ApiController]
[Route("players")]
public class PlayersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlayersController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlayerRequest request, CancellationToken cancellationToken)
    {
        Guid id;
        try
        {
            id = await _mediator.Send(new CreatePlayerCommand(request.Name, request.Score));
        }
        catch (ArgumentException ex) // covers ArgumentOutOfRangeException (negative score) too
        {
            return BadRequest(new { error = ex.Message });
        }

        // 3-arg overload — the 2-arg CreatedAtAction throws "No route matches" on this runtime.
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var player = await _mediator.Send(new GetPlayerByIdQuery(id));
        return player is null ? NotFound() : Ok(PlayerResponse.From(player));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var players = await _mediator.Send(new GetAllPlayersQuery());
        return Ok(players.Select(PlayerResponse.From));
    }
}