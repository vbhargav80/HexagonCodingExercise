namespace Hexagon.Domain.Interfaces
{
    public interface ICommandFactory
    {
        ICommand Create(string inputLine, Robot receiver);
    }
}