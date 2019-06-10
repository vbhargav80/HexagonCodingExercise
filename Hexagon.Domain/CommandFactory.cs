using System;
using Hexagon.Domain.Commands;
using Hexagon.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hexagon.Domain
{
    public class CommandFactory : ICommandFactory
    {
        private readonly ILogger<CommandFactory> _logger;

        public CommandFactory(ILogger<CommandFactory> logger)
        {
            _logger = logger;
        }

        public ICommand Create(string inputLine, Robot receiver)
        {
            ICommand parsedCommand = null;
            var upperCaseInput = inputLine.ToUpper();

            if (upperCaseInput.StartsWith("PLACE"))
            {
                parsedCommand = ParsePositionCommand(upperCaseInput, receiver);
            }
            else if (upperCaseInput == "MOVE")
            {
                parsedCommand = new MoveCommand(receiver);
            }
            else if (upperCaseInput == "LEFT")
            {
                parsedCommand = new TurnLeftCommand(receiver);
            }
            else if (upperCaseInput == "RIGHT")
            {
                parsedCommand = new TurnRightCommand(receiver);
            }
            else if (upperCaseInput == "REPORT")
            {
                parsedCommand = new ReportCommand(receiver);
            }
            else
            {
                _logger.LogWarning($"Ignoring invalid command: {inputLine}");
                Console.WriteLine($"Ignoring invalid command: {inputLine}");
            }

            return parsedCommand;
        }

        private PlaceCommand ParsePositionCommand(string inputLine, Robot receiver)
        {
            var commandArgs = inputLine.Replace("PLACE", "").Trim();
            var fragments = commandArgs.Split(",", StringSplitOptions.RemoveEmptyEntries);

            if (fragments.Length != 3)
            {
                _logger.LogWarning($"Ignoring invalid command: {inputLine}");
                return null;
            }

            if (!int.TryParse(fragments[0], out int xCoordinate))
            {
                _logger.LogWarning($"Ignoring invalid command: {inputLine}");
                return null;
            }

            if (!int.TryParse(fragments[1], out int yCoordinate))
            {
                _logger.LogWarning($"Ignoring invalid command: {inputLine}");
                return null;
            }

            if (!Enum.TryParse(fragments[2], true, out Direction direction))
            {
                _logger.LogWarning($"Ignoring invalid command: {inputLine}");
                return null;
            }

            var position = new Position()
            {
                Direction = direction,
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            };

            return new PlaceCommand(receiver, position);
        }
    }
}
