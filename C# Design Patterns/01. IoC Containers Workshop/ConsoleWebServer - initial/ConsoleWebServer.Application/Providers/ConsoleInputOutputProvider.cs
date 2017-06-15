using System;

namespace ConsoleWebServer.Application.Providers
{
    public class ConsoleInputOutputProvider : IInputOutputProvider
    {
        public string ReadLine()
        {
            string lineRead = Console.ReadLine();
            return lineRead;
        }

        public void WriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
