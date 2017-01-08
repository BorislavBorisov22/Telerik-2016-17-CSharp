namespace Timer
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var timer = new Timer(3, Print);
            timer.Start(15);
        }

        public static void Print(string input)
        {
            Console.WriteLine(input);
        }
    }
}
