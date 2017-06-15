using Academy.Commands.Contracts;

namespace Academy.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
