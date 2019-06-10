using Hexagon.Domain;
using Hexagon.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagon.App
{
    public static class ContainerConfig
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddLogging()
                .AddSingleton<IRobotController, RobotController>()
                .AddSingleton<ICommandFactory, CommandFactory>()
                .BuildServiceProvider();
        }
    }
}
