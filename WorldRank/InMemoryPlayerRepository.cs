using WorldRank.main;
using WorldRank.@int;
namespace WorldRank;

public class InMemoryPlayerRepository : IPlayerRepository
{
    private readonly List<Player> _players = new();

    public void AddPlayer(Player p) => _players.Add(p);

    public Player? FindPlayer(int playerId) => _players.FirstOrDefault(p => p.Id == playerId);

    public Player? FindByName(string name) => _players.FirstOrDefault(p =>
            p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public void DeletePlayer(int playerId)
    {
        var player = FindPlayer(playerId);
        if (player is not null)
            _players.Remove(player);
    }

    public IEnumerable<Player> GetAll() => _players;

    public IEnumerable<IGrouping<int, Player>> GetPlayersGroupedByScore() =>
    _players.GroupBy(p => p.Score).OrderByDescending(g => g.Key);
}