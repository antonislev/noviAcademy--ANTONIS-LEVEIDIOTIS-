using MediatR;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Wallets
{
    public record GetWalletsByPlayerQuery(Guid PlayerId)
       : IRequest<IReadOnlyList<Wallet>>, ICachedQuery
    {
        public string CacheKey => CacheKeys.PlayerWallets(PlayerId);
    }
}
