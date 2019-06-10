namespace Hexagon.Domain.Interfaces
{
    public interface ICommand
    {
        Robot Receiver { get; }
        void Execute();
    }
}
