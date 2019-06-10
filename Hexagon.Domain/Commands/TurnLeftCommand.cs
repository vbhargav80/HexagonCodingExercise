using Hexagon.Domain.Interfaces;

namespace Hexagon.Domain.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public Robot Receiver { get; }

        public TurnLeftCommand(Robot receiver)
        {
            Receiver = receiver;
        }

        public void Execute()
        {
            Receiver.TurnLeft();
        }
    }
}
