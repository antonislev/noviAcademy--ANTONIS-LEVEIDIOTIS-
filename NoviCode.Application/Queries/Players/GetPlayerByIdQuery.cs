using MediatR;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Players
{
    public record GetPlayerByIdQuery(Guid Id) : IRequest<Player?>, ICachedQuery
    {
        public string CacheKey => CacheKeys.Player(Id);
    }
}
