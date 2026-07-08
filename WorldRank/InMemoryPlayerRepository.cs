using WorldRank.main;
using WorldRank.@int;
using Microsoft.Extensions.Logging;
namespace WorldRank;

public class InMemoryPlayerRepository : IPlayerRepository
{
    private readonly List<Player> _players = new();
    private readonly ILogger<InMemoryPlayerRepository> _logger;

    public InMemoryPlayerRepository(ILogger<InMemoryPlayerRepository> logger)
    {
        _logger = logger;
    }

    public void AddPlayer(Player p)
    {
        _players.Add(p);
        _logger.LogInformation("Player added: {PlayerName} with ID {PlayerId}", p.Name, p.Id);
    }

    public Player? FindPlayer(int playerId)
    {
        var player = _players.FirstOrDefault(p => p.Id == playerId);
        if (player is null)
        {
            _logger.LogWarning("Player with ID {PlayerId} not found.", playerId);
        }
        return player;
    }
    public Player? FindByName(string name) => _players.FirstOrDefault(p =>
            p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public void DeletePlayer(int playerId)
    {
        var player = FindPlayer(playerId);
        if (player is not null)
        {
            _players.Remove(player);
            _logger.LogInformation("Player deleted: {PlayerName} with ID {PlayerId}", player.Name, player.Id);
        }
            
    }

    public IEnumerable<Player> GetAll() => _players;

    public IEnumerable<IGrouping<int, Player>> GetPlayersGroupedByScore() =>
    _players.GroupBy(p => p.Score).OrderByDescending(g => g.Key);
}