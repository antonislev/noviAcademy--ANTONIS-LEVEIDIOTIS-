using WorldRank.main;

namespace WorldRank.@int;

public interface IWalletRepository
{
    void Add(Wallet wallet, int playerId);
    IEnumerable<Wallet> GetByPlayer(int playerId);
}