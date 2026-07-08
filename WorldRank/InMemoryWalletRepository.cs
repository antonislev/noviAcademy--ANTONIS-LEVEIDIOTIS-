using Microsoft.Extensions.Logging;
using WorldRank.@int;
using WorldRank.main;

namespace WorldRank;

public class InMemoryWalletRepository : IWalletRepository
{
    private readonly IPlayerRepository _playerRepo;
    private readonly ILogger<InMemoryWalletRepository> _logger;
    public InMemoryWalletRepository(IPlayerRepository playerRepo, ILogger<InMemoryWalletRepository> logger)
    {
        _playerRepo = playerRepo;
        _logger = logger;
    }

    public void Add(Wallet wallet, int playerId)
    {
        var player = _playerRepo.FindPlayer(playerId);
        if (player is null)
            throw new InvalidOperationException($"Player {playerId} not found.");
        

        player.AddWallet(wallet);
    }

    public IEnumerable<Wallet> GetByPlayer(int playerId)
    {
        var player = _playerRepo.FindPlayer(playerId);
        return player is null
            ? Enumerable.Empty<Wallet>()
            : player.Wallets.Values;
    }
}