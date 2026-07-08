namespace WorldRank.main;

using WorldRank.@int;
public class Player : IPlayer
{
   
   
    private static int _nextId = 1;
    public int Id { get; }
    public string Name { get; }
    public int Score { get; private set; }

    private readonly Dictionary<Currency, Wallet> _wallets = new();
    public Dictionary<Currency, Wallet> Wallets { get; } = new();


    public Player(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        Id = _nextId++;
        Name = name;
    }

    public void UpdateScore(int newScore)
    {
        if (newScore < 0)
            throw new ArgumentOutOfRangeException(nameof(newScore), "Score cannot be negative.");

        Score = newScore;
    }
    
    internal void AddWallet(Wallet wallet)
    {
        if (wallet.PlayerId != Id)
            throw new InvalidOperationException("Wallet does not belong to this player.");
        if (_wallets.ContainsKey(wallet.Currency))
            throw new InvalidOperationException($"Player {Id} already has a {wallet.Currency} wallet.");
        _wallets[wallet.Currency] = wallet;
    }
    public override string ToString() =>
            $"[{Id}] {Name} - Score: {Score}";
}