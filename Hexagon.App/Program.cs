using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagon.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var serviceProvider =  ContainerConfig.Configure();
            var application = serviceProvider.GetService<IRobotController>();

            if (config.GetValue("readCommandsFromFile", false))
            {
                application.ProcessCommandsFromFile();
            }
            else
            {
                application.ProcessCommandsFromUserInput();
            }
        }
    }
}
