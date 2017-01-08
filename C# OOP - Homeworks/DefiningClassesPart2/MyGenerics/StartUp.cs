namespace Test
{
    using System;
    using MyGenerics;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
             var list = new GenericList<int>(20);

             list.Add(15);
             list.Add(22);
             list.Add(44);
             list.Add(-22);
             list.Add(-18);
             list.Add(int.MaxValue);

             // list after only adding elements in it -> 15, 22, 44, -22, -18, int.MaxValue
             Console.WriteLine(list);
             list.InsertAt(2, 1024);

             // list after inserting element at given index
             // 15, 22, 1024, 44, -22, -18, int.MaxValue
             Console.WriteLine(list);

             list.RemoveAt(0);
             // list after removing element at given index
             // 22, 1024, 44, -22, -18, int.MaxValue*/
            
            Console.WriteLine(list);

            Console.WriteLine("list[2] = {0}", list[2]);
            Console.WriteLine("Max item: list[{0}] = {1}", list.GetElementIndex(list.Max()), list.Max());
            Console.WriteLine("Min item: list[{0}] = {1}", list.GetElementIndex(list.Min()), list.Min());
            Console.WriteLine("Capacity: {0}, Count: {1}", list.Capacity, list.ElementsCount);
            list.Clear();
            Console.WriteLine("Count after clearing list: {0}", list.ElementsCount);
            // printed list after being cleared
            Console.WriteLine(list); 
        }
    }
}
