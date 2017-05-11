namespace SchoolSystem.Tests.Core.Engine.Fakes
{
    using SchoolSystem.Contracts;
    using SchoolSystem.Core;

    public class FakeEngine : Engine
    {
        public FakeEngine(IReaderProvider reader, IWriterProvider writer, ICommandProvider commandProvider) 
            : base(reader, writer, commandProvider)
        {
        }

        public IReaderProvider ReaderProviderExposed
        {
            get
            {
                return base.Reader;
            }
        }

        public IWriterProvider WriterProviderExposed
        {
            get
            {
                return base.Writer;
            }
        }

        public ICommandProvider CommandProviderExposed
        {
            get
            {
                return base.CommandProvider;
            }
        }
    }
}
