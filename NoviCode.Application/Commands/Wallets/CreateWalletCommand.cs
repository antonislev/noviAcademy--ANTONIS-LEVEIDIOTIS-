using MediatR;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Commands.Wallets
{
    public record CreateWalletCommand(Guid PlayerId, Currency Currency)
        : IRequest<Wallet>, ICacheInvalidatingCommand<Wallet>
    {
        // A new wallet changes the "all wallets" list and this player's wallet list.
        public IEnumerable<string> CacheKeysToInvalidate(Wallet result) =>
            new[] { CacheKeys.AllWallets, CacheKeys.PlayerWallets(PlayerId) };
    }
}
