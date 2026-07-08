using System;

public class Player
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string Team { get; private set; }
    public int Score { get; protected set; }

    public Player(string name, string team, int score)
    {
        Name = name;
        Team = team;
        Score = score;
    }

    public override string ToString()
    {
        return $"Player: {Name}, Team: {Team}, Score: {Score}";
    }

    public void UpdateScore(int newScore)
    {
        Score = newScore;
    }
}
