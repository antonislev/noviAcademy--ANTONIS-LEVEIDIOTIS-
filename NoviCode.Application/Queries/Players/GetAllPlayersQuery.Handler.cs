using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Players
{
    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IReadOnlyList<Player>>
    {
        private readonly IPlayerRepository _players;

        public GetAllPlayersQueryHandler(IPlayerRepository players) => _players = players;

        public Task<IReadOnlyList<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken) =>
            _players.GetAllAsync(cancellationToken);
    }
}
