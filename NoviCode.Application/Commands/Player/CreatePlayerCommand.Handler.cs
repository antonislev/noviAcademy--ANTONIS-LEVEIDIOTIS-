using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Commands.Players
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Guid>
    {
        private readonly IPlayerRepository _players;

        public CreatePlayerCommandHandler(IPlayerRepository players) => _players = players;

        public async Task<Guid> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = Player.CreateNew(request.name); // throws ArgumentException on empty name
            player.UpdateScore(request.score);           // throws on negative score (was missing before)

            await _players.AddAsync(player, cancellationToken);
            return player.Id;
        }
    }
}