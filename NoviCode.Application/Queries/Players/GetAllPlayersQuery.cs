using MediatR;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Players
{
    public record GetAllPlayersQuery() : IRequest<IReadOnlyList<Player>>, ICachedQuery
    {
        public string CacheKey => CacheKeys.AllPlayers;
    }
}
