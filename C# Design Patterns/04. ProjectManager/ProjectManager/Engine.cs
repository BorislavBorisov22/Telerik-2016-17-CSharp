using Bytes2you.Validation;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using System;
using System.Text;

namespace ProjectManager
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ILogger logger;
        private readonly IProcessor processor;

        public Engine(IReader reader, IWriter writer, ILogger logger, IProcessor processor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(logger, "logger").IsNull().Throw();
            Guard.WhenArgument(processor, "processor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.logger = logger;
            this.processor = processor;
        }

        public void Start()
        {
            var builder = new StringBuilder();

            while (true)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == TerminationCommand)
                {
                    this.writer.Write(builder.ToString());
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(commandLine);
                    builder.AppendLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    builder.AppendLine(ex.Message);
                }
                catch (Exception ex)
                {
                    builder.AppendLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
