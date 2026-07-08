using WorldRank.main;

namespace WorldRank.@int;

public interface IPlayerRepository
{
    void AddPlayer(Player p);
    Player? FindPlayer(int playerId);
    void DeletePlayer(int playerId);
    
    IEnumerable<IGrouping<int, Player>> GetPlayersGroupedByScore();
}

