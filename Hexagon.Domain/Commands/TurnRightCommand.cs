using Hexagon.Domain.Interfaces;

namespace Hexagon.Domain.Commands
{
    public class TurnRightCommand : ICommand
    {
        public Robot Receiver { get; private set; }

        public TurnRightCommand(Robot receiver)
        {
            Receiver = receiver;
        }

        public void Execute()
        {
            Receiver.TurnRight();
        }
    }
}
