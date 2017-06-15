using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory ?? throw new ArgumentNullException("CommandFactory cannot be null!");
        }
        
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var command = this.commandFactory.GetCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
