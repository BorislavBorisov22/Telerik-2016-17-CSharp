using SchoolSystem.Contracts;
using SchoolSystem.Core;

namespace SchoolSystem
{
    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at leest 2 more provider like this one
            IReaderProvider reader = new ConsoleReaderProvider();
            IWriterProvider writer = new ConsoleWriterProvider();
            ICommandProvider commandProvider = new CommandProvider();

            var engine = new Engine(reader, writer, commandProvider);
            engine.Start();
        }
    }
}
