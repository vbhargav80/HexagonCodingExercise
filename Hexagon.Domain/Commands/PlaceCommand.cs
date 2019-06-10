using Hexagon.Domain.Interfaces;

namespace Hexagon.Domain.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly Position _position;

        public PlaceCommand(Robot receiver, Position position)
        {
            Receiver = receiver;
            _position = position;
        }

        public Robot Receiver { get; }

        public void Execute()
        {
            Receiver.SetPosition(_position);
        }
    }
}
