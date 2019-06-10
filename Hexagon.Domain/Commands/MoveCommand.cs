using System;
using System.Collections.Generic;
using System.Text;
using Hexagon.Domain.Interfaces;

namespace Hexagon.Domain.Commands
{
    public class MoveCommand : ICommand
    {
        public Robot Receiver { get; }

        public MoveCommand(Robot receiver)
        {
            Receiver = receiver;
        }

        public void Execute()
        {
            Receiver.Move();
        }
    }
}
