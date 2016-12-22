namespace GSM
{
    using System;
    using GSM.Test;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("GSM TEST");
            GSMTest.TestPhones();
            Console.WriteLine();
            Console.WriteLine("Call History TEST");
            GSMCallHistoryTest.TestHistory();
        }
    }
}
