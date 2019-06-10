using System;
using Hexagon.Domain;
using Hexagon.Domain.Commands;
using Hexagon.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Hexagon.App
{
    public class RobotController : IRobotController
    {
        private readonly ILogger<RobotController> _logger;
        private readonly ICommandFactory _commandFactory;

        public RobotController(ILogger<RobotController> logger, ICommandFactory commandFactory)
        {
            _logger = logger;
            _commandFactory = commandFactory;
        }

        public void ProcessCommandsFromUserInput()
        {
            Console.WriteLine("Please enter commands. An empty line will exit the app.");
            string input;
            bool hasReceivedFirstPlaceCommand = false;

            var robot = new Robot(new TableDimensions());

            do
            {
                input = Console.ReadLine();
                var command = _commandFactory.Create(input, robot);
                
                if (!(command is PlaceCommand) && !hasReceivedFirstPlaceCommand)
                    continue;

                hasReceivedFirstPlaceCommand = true;
                command?.Execute();

            } while (!string.IsNullOrEmpty(input));
        }

        public void ProcessCommandsFromFile()
        {
            Console.Write("Please enter the full path to the file containing commands (eg: C:/TestFile.txt): ");
            var robot = new Robot(new TableDimensions());
            bool hasReceivedFirstPlaceCommand = false;
            bool fileExists = false;
            string filePath;

            do
            {
                filePath = Console.ReadLine();
                fileExists = File.Exists(filePath);

                if (!fileExists)
                {
                    Console.Write($"File {filePath} does not exist. Please try again (eg: C:/TestFile.txt): ");
                }
                else
                {
                    foreach (var inputCommand in File.ReadAllLines(filePath))
                    {
                        var command = _commandFactory.Create(inputCommand, robot);
                        if (!(command is PlaceCommand) && !hasReceivedFirstPlaceCommand)
                            continue;

                        hasReceivedFirstPlaceCommand = true;
                        command?.Execute();
                    }


                    Console.Write(Environment.NewLine + "Please enter any key to exit the app. ");
                    Console.ReadKey();
                }

            } while (!fileExists);
        }
    }
}
