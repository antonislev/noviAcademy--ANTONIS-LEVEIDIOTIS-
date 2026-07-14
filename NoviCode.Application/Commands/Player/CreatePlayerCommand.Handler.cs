using MediatR;
using NoviCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Commands.Player
{
    public class CreatePlayerCommand : IRequestHandler<CreatePlayerCommand>
    {
        public readonly ICreatePlayerPersistence _createPlayerPersistence;
        public CreatePlayerCommand(ICreatePlayerPersistence createPlayerPersistence)
        {
            _createPlayerPersistence = createPlayerPersistence;
        }
        
    }
}