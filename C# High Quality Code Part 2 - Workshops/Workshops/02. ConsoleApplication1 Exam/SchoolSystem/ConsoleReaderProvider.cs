using SchoolSystem.Contracts;
using System;

namespace SchoolSystem
{
    public class ConsoleReaderProvider : IReaderProvider
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string ReadLine() 
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
