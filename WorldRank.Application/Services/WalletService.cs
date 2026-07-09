using WorldRank.Application.interfaces;
using WorldRank.Application.Strategies;
using WorldRank.Domain.Entities;
using WorldRank.Domain.Enums;

namespace WorldRank.Application.Services
{
    public class WalletService
    {
        private readonly Dictionary<FundsOperation, IFoundsStrategy> _strategies;

        public WalletService(IEnumerable<IFoundsStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.Operation);
        }

        public void Execute(FundsOperation operation, Wallet wallet, decimal amount)
        {
            if (!_strategies.TryGetValue(operation, out var strategy))
                throw new InvalidOperationException($"No strategy registered for {operation}.");

            strategy.Execute(wallet, amount);
        }
    }
}