using Bytes2you.Validation;
using Dealership.CommandHandlers.Contracts;
using Dealership.Engine.Providers.Contracts;
using Dealership.Factories.Contracts;
using System;
using System.Collections.Generic;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private readonly ICommandHandler commandHandler;
        private readonly ICommandFactory commandFactory;
        private readonly IInputOutputProvider inputOutputProvider;
        private readonly IReportsProvider reportsProvider;

        public DealershipEngine(ICommandHandler commandHandler, ICommandFactory commandFactory, IInputOutputProvider inputOutputProvider,
            IReportsProvider reportsProvider)
        {
            Guard.WhenArgument(commandHandler, "commandHandler").IsNull().Throw();
            Guard.WhenArgument(inputOutputProvider, "inputOutputProvider").IsNull().Throw();
            Guard.WhenArgument(commandFactory, "commandFactory").IsNull().Throw();
            Guard.WhenArgument(reportsProvider, "reportsProvider").IsNull().Throw();

            this.commandHandler = commandHandler;
            this.inputOutputProvider = inputOutputProvider;
            this.commandFactory = commandFactory;
            this.reportsProvider = reportsProvider;
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            this.ProcessCommands(commands);
            this.reportsProvider.PrintReports(this.inputOutputProvider);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.inputOutputProvider.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.commandFactory.CreateCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.inputOutputProvider.ReadLine();
            }

            return commands;
        }

        private void ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.commandHandler.ProcessCommand(command);
                    this.reportsProvider.AddReport(report);
                }
                catch (Exception ex)
                {
                    this.reportsProvider.AddReport(ex.Message);
                }
            }
        }
    }
}
