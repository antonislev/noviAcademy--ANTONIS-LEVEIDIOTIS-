using Microsoft.AspNetCore.Mvc;
using WorldRank.Domain.Entities;
using WorldRank.Application.Interfaces;


namespace WorldRank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = _playerRepository.GetAllPlayers();
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet("{playerId:guid}")]
        public async Task<IActionResult> GetById(int playerId)
        {
            try
            {
                var all = _playerRepository.FindPlayer(playerId);
                if (all == null) return NotFound();

                return Ok(all);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}
