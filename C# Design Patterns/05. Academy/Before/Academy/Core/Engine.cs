using Academy.Core.Contracts;
using System;
using System.Text;

namespace Academy.Core
{
    public class Engine : IEngine
    {
      
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private readonly StringBuilder builder = new StringBuilder();

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser commandParser;
       
        public Engine(IReader reader, IWriter writer, IParser parser)
        {
            this.reader = reader ?? throw new ArgumentNullException("Reader cannot be null!");
            this.writer = writer ?? throw new ArgumentNullException("Writer cannot be null!");
            this.commandParser = parser ?? throw new ArgumentNullException("Parser cannot be null!");
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.commandParser.ParseCommand(commandAsString);
            var parameters = this.commandParser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.builder.AppendLine(executionResult);
        }
    }
}
