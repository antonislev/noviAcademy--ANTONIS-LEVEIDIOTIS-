using MediatR;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Wallets
{
    public record GetWalletByIdQuery(Guid Id) : IRequest<Wallet?>, ICachedQuery
    {
        public string CacheKey => CacheKeys.Wallet(Id);
    }
}
