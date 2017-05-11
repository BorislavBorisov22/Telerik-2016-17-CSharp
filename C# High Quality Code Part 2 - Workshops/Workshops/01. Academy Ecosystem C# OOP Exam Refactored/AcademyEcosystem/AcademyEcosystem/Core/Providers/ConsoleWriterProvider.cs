using System;
using AcademyEcosystem.Core.Contracts;

namespace AcademyEcosystem.Core
{
    internal class ConsoleWriterProvider : IWriterProvider
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
