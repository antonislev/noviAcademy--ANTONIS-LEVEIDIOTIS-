namespace WorldRank;

public class InMemoryWalletRepository : IWalletRepository
{
    private readonly IPlayerRepository _playerRepo;

    public InMemoryWalletRepository(IPlayerRepository playerRepo)
    {
        _playerRepo = playerRepo;
    }

    public void Add(Wallet wallet, int playerId)
    {
        var player = _playerRepo.FindPlayer(playerId);
        if (player is null)
            throw new InvalidOperationException($"Player {playerId} not found.");

        if (player.Wallets.ContainsKey(wallet.Currency))
            throw new InvalidOperationException(
                $"Player {playerId} already has a {wallet.Currency} wallet.");

        player.Wallets[wallet.Currency] = wallet;
    }

    public IEnumerable<Wallet> GetByPlayer(int playerId)
    {
        var player = _playerRepo.FindPlayer(playerId);
        return player is null
            ? Enumerable.Empty<Wallet>()
            : player.Wallets.Values;
    }
}