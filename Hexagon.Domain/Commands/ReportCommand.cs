using System;
using Hexagon.Domain.Interfaces;

namespace Hexagon.Domain.Commands
{
    public class ReportCommand : ICommand
    {
        public Robot Receiver { get; }

        public ReportCommand(Robot receiver)
        {
            Receiver = receiver;
        }

        public void Execute()
        {
            if (Receiver.CurrentPosition == null)
            {
                Console.WriteLine("Robot has not been placed on the table. Ignoring Report command...");
                return;
            }

            Console.WriteLine("{0},{1},{2}",
                Receiver.CurrentPosition.XCoordinate,
                Receiver.CurrentPosition.YCoordinate,
                Receiver.CurrentPosition.Direction.ToString().ToUpper()
                );
        }
    }
}
