using AcademyEcosystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyEcosystem
{
    public class Engine
    {
        private const string TerminationCommand = "end";

        private static readonly char[] Separators = new char[] { ' ' };

        private IReaderProvider reader;
        private IWriterProvider writer;
        private ICommandProvider commandProvider;

        public Engine(IReaderProvider reader, IWriterProvider writer, ICommandProvider commandProvider)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Engine ReaderProvider cannot be null!");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("Engine WriterProvider cannot be null!");
            }

            if (commandProvider == null)
            {
                throw new ArgumentNullException("Engine CommandProvider cannot be null!");
            }

            this.reader = reader;
            this.writer = writer;
            this.commandProvider = commandProvider;

            AllOgranisms = new List<IOrganism>();
            Plants = new List<IPlant>();
            Animals = new List<IAnimal>();
        }

        internal static IList<IOrganism> AllOgranisms { get; private set; }

        internal static IList<IPlant> Plants { get; private set; }

        internal static IList<IAnimal> Animals { get; private set; }

        protected IWriterProvider Writer
        {
            get
            {
                return this.writer;
            }
        }

        protected IReaderProvider Reader
        {
            get
            {
                return this.reader;
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
            string command = this.reader.ReadLine();
            while (command != TerminationCommand)
            {
                try
                {
                    var commandParameters = command
                        .Split(Separators, StringSplitOptions.RemoveEmptyEntries);

                    var commandArgs = command
                        .Split(Separators, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    commandArgs.RemoveAt(0);

                    var commandToExecute = this.commandProvider.GetCommand(commandParameters);

                    string commandMessage = commandToExecute.Execute(commandArgs);

                    if (commandMessage.Trim() != string.Empty)
                    {
                        this.writer.WriteLine(commandMessage);
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

                command = this.reader.ReadLine();
            }
        }
    }
}
