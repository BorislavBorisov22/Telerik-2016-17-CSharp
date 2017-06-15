using Bytes2you.Validation;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using System.Linq;

namespace ProjectManager.Common.Providers
{
    public class CommandProcessor : IProcessor
    {
        private ICommandsFactory commandsFactory;

        public CommandProcessor(ICommandsFactory factory)
        {
            Guard.WhenArgument(factory, "commandsFactory").IsNull().Throw();

            this.commandsFactory = factory;
        }

        public string ProcessCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new UserValidationException("No command has been provided!");
            }

            var commandName = commandLine.Split(' ')[0];
            var commandParameters = commandLine
                .Split(' ')
                .Skip(1)
                .ToList();

            var command = this.commandsFactory.GetCommand(commandName);
            var executionResult = command.Execute(commandParameters);

            return executionResult;
        }
    }
}
