namespace AcademyEcosystem.Tests.Core
{
    using AcademyEcosystem.Core.Contracts;

    internal class FakeEngine : Engine
    {
        public FakeEngine(IReaderProvider reader, IWriterProvider writer, ICommandProvider commandProvider) 
            : base(reader, writer, commandProvider)
        {
        }

        public IReaderProvider TestReader
        {
            get
            {
                return this.Reader;
            }
        }

        public IWriterProvider TestWriter
        {
            get
            {
                return this.Writer;
            }
        }

        public ICommandProvider TestCommandProvider
        {
            get
            {
                return this.CommandProvider;
            }
        }
    }
}
