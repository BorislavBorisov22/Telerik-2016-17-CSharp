using SchoolSystem.Contracts;
using System;

namespace SchoolSystem
{
    public class ConsoleWriterProvider : IWriterProvider
    {
        // bottleneck ;)
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
