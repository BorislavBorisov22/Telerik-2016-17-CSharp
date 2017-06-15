using Dealership.Engine;

namespace Dealership.CommandHandlers.Contracts
{
    public interface ICommandHandler
    {
        void SetSuccessor(ICommandHandler commandHandler);

        string ProcessCommand(ICommand command);
    }
}
