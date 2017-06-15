namespace ProjectManager.Commands.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
