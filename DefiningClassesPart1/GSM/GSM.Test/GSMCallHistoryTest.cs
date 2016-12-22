namespace GSM.Test
{
    using System;
    using GSM.Components;

    public static class GSMCallHistoryTest
    {
        public const decimal CallPricePerMinute = 0.37m;

        public static void TestHistory()
        {
            var gsm = new GSM("Iphone 4S", "Apple");

            // adding some calls to gsm's call history and then printing the hole information about them
            gsm.AddCall(DateTime.Now, "0878856032", 360);
            gsm.AddCall(new DateTime(2014, 12, 12, 12, 23, 45), "09461596512", 450);
            gsm.AddCall(new DateTime(2016, 12, 08, 13, 00, 00), "0877456091", 1000);
            gsm.AddCall(DateTime.Today, "+35985609114", 120);

            Console.WriteLine(gsm.CallHistory);

            // print total price for calls of gsm
            Console.WriteLine("Total price for calls: {0}$", gsm.TotalCallsPrice(CallPricePerMinute));

            // remove longest call and print again the total price for the calls
            gsm.RemoveLongestCall();
            Console.WriteLine("Total price for calls after removing longest call: {0}$", gsm.TotalCallsPrice(CallPricePerMinute));

            // clear all call history from gsm and try to print the call history againg
            // the output should say that the call history is empty
            gsm.ClearCallHistory();
            Console.WriteLine("Output after clearing call history: {0}", gsm.CallHistory);
        }
    }
}
