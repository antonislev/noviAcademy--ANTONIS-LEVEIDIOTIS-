using System;
using System.Collections.Generic;
using System.Linq;

public interface IPlayerRegister
{
    void Add(Player player);
    bool Remove(Guid id);
    bool UpdateScore(Guid id, int newScore);
    IEnumerable<Player> GetAll();
}

public class PlayerRegister : IPlayerRegister
{
    private readonly List<Player> players = new List<Player>();

    public void Add(Player player) => players.Add(player);

    public bool Remove(Guid id)
    {
        var p = players.FirstOrDefault(x => x.Id == id);
        if (p == null) return false;
        players.Remove(p);
        return true;
    }

    public bool UpdateScore(Guid id, int newScore)
    {
        var p = players.FirstOrDefault(x => x.Id == id);
        if (p == null) return false;
        p.UpdateScore(newScore);
        return true;
    }

    public IEnumerable<Player> GetAll() => players;
}