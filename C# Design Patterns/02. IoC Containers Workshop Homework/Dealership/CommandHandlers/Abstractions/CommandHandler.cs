using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public abstract class CommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command!";

        private ICommandHandler commandHandler;

        public string ProcessCommand(ICommand command)
        {
            if (this.CanHandle(command))
            {
                return this.Process(command);
            }

            if (this.commandHandler != null)
            {
                return this.commandHandler.ProcessCommand(command);
            }

            return string.Format(InvalidCommand, command.Name);
        }

        public void SetSuccessor(ICommandHandler commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Process(ICommand command);
    }
}
