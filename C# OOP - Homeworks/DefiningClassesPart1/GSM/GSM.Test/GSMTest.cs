namespace GSM.Test
{
    using System;
    using System.Collections.Generic;
    using GSM.Components;

    public static class GSMTest
    {
        public static void TestPhones()
        {
            var phonesList = new List<GSM>();
            var firstPhone = new GSM("Galaxy S7", "Samsung", 1425, "Ivan", new Battery(BatteryType.Li_Ion, 125, 19), new Display(3.45, 2034543));
            var secondPhone = new GSM("Xperia Z4", "Sony", 543, "Stamat", new Battery(BatteryType.NiMH, 48, 12), new Display(3.22, 106543));
            var thirdPhone = new GSM("Lumia", "Nokia", 421.18m, "Stenli", new Battery(BatteryType.NiCd, 67, 25), new Display(2.18, 2034543));
            var fourthPhone = new GSM("Iphone 6S", "Apple");
            var fifthPhone = new GSM("A505", "Lenovo", 960.99m, "Penka", new Battery());

            phonesList.Add(firstPhone);
            phonesList.Add(secondPhone);
            phonesList.Add(thirdPhone);

            // phonesList.Add(fourthPhone);

            // phonesList.Add(firstPhone);
            foreach (var phone in phonesList)
            {
                Console.WriteLine(phone);
                Console.WriteLine("==============================");
            }

            Console.WriteLine(GSM.Iphone4S);
        }
    }
}
