namespace Dealership.Engine
{
    using Contracts;
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
