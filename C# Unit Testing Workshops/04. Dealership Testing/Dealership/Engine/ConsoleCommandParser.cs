namespace Dealership.Engine
{
    using System;
    using System.Collections.Generic;
    using Dealership.Contracts;

    public class ConsoleCommandParser : ICommandParser
    {
        public IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = new Command(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }
    }
}
