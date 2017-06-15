using Dealership.Engine.Providers.Contracts;
using System;

namespace Dealership.Engine.Providers
{
    public class InputOutputProvider : IInputOutputProvider
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }

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
