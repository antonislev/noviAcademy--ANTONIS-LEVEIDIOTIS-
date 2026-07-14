using Autofac.Core.Registration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Commands.Player
{
    public record CreatePlayerCommand(string name, in score) : IRequest;

}