using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Queries.Players
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player?>
    {
        private readonly IPlayerRepository _players;

        public GetPlayerByIdQueryHandler(IPlayerRepository players) => _players = players;

        public Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken) =>
            _players.GetByIdAsync(request.Id, cancellationToken);
    }
}
