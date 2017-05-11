using SchoolSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Core
{
    public class Engine
    {
        private const string TerminationCommand = "End";

        private IWriterProvider writer;
        private ICommandProvider commandProvider;
        private IReaderProvider reader;

        public Engine(IReaderProvider reader, IWriterProvider writer, ICommandProvider commandProvider)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Reader cannot be null!");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("Writer cannot be null!");
            }

            if (commandProvider == null)
            {
                throw new ArgumentNullException("Validator cannot be null!");
            }

            this.commandProvider = commandProvider;
            this.writer = writer;
            this.reader = reader;
        }

        internal static Dictionary<int, ITeacher> Teachers { get; set; } = new Dictionary<int, ITeacher>();

        internal static Dictionary<int, IStudent> Students { get; set; } = new Dictionary<int, IStudent>();

        // exposing class dependencies through properties in the deriving classes for 
        // testing purposes
        protected IReaderProvider Reader
        {
            get
            {
                return this.reader;
            }
        }

        protected IWriterProvider Writer
        {
            get
            {
                return this.writer;
            }
        }

        protected ICommandProvider CommandProvider
        {
            get
            {
                return this.commandProvider;
            }
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var lineRead = this.reader.ReadLine();

                    if (lineRead == TerminationCommand)
                    {
                        break;
                    }

                    var commandName = lineRead.Split(' ')[0];

                    ICommand command = this.commandProvider.GetCommand(commandName);

                    var commandParameters = lineRead.Split(' ').ToList();
                    commandParameters.RemoveAt(0);

                    this.writer.WriteLine(command.Execute(commandParameters));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
