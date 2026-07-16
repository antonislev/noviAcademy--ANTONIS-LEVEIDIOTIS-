using MediatR;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Commands.Players
{
    public record CreatePlayerCommand(string name, int score)
        : IRequest<Guid>, ICacheInvalidatingCommand<Guid>
    {
        // Creating a player changes the "all players" list view; evict it so the next
        // GetAllPlayers reloads the new row from the DB.
        public IEnumerable<string> CacheKeysToInvalidate(Guid result) => new[] { CacheKeys.AllPlayers };
    }
}