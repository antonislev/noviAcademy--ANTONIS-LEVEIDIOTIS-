using Microsoft.Extensions.Logging;
using WorldRank.@int;
using WorldRank.main;
using WorldRank.exe;

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
        {
            _logger.LogWarning("Player with ID {PlayerId} not found. Cannot add wallet.", playerId);
            return;
            throw new Playernotfound($"Player with ID {playerId} not found. Cannot add wallet.");
        }        

        player.AddWallet(wallet);
        _logger.LogInformation("Wallet for currency {Currency} added to player {PlayerId}.", wallet.Currency, playerId);
    }

    public IEnumerable<Wallet> GetByPlayer(int playerId)
    {
        var player = _playerRepo.FindPlayer(playerId);
        if (player is null)
            {
            _logger.LogWarning("Player with ID {PlayerId} not found. Cannot retrieve wallets.", playerId);
            throw new Playernotfound($"Player with ID {playerId} not found. Cannot retrieve wallets.");
            
        }
       
            return player.Wallets.Values;
        }
}