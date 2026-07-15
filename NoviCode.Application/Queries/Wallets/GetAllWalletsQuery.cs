using MediatR;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Wallets
{
    public record GetAllWalletsQuery() : IRequest<IReadOnlyList<Wallet>>, ICachedQuery
    {
        public string CacheKey => CacheKeys.AllWallets;
    }
}
