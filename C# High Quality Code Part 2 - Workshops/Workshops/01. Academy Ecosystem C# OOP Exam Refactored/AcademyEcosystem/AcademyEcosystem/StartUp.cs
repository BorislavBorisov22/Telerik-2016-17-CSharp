using AcademyEcosystem.Core;
using AcademyEcosystem.Core.Contracts;

namespace AcademyEcosystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = GetEngineInstance();
            engine.Start();
        }

        private static Engine GetEngineInstance()
        {
            IWriterProvider writer = new ConsoleWriterProvider();
            IReaderProvider reader = new ConsoleReaderProvider();
            ICommandProvider commandProvider = new CommandProvider();
            Engine engine = new Engine(reader, writer, commandProvider);

            return engine;
        }
    }
}
