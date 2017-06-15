using Dealership.Engine;

namespace Dealership.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string input);
    }
}
