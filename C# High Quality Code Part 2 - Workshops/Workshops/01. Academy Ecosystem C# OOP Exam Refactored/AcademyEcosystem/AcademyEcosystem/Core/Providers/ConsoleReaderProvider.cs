using System;
using AcademyEcosystem.Core.Contracts;

namespace AcademyEcosystem.Core
{
    internal class ConsoleReaderProvider : IReaderProvider
    {
        public string ReadLine()
        {
            string lineRead = Console.ReadLine();
            return lineRead;
        }
    }
}
