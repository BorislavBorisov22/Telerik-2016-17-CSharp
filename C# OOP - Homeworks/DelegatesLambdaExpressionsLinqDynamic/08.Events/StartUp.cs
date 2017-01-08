namespace Events
{
    using System;
    

    public class StartUp
    {
        public static void Main()
        {
            /* The following program's purpose is to simulate the raising of an event 
             * and communication between a publisher and it's subscribers. In our case we
             * simulate a a timer that executes a given methods in a given interval
             * for given total time for execution in seconds.*/
            
            var timer = new Timer(3,Print);
            var subscriber = new Subscriber();

            timer.IntervalReached += subscriber.OnIntervalReached;
            timer.Start(15);
        }
        
        public static void Print(string input)
        {
            Console.WriteLine(input);
        } 
    }
}
