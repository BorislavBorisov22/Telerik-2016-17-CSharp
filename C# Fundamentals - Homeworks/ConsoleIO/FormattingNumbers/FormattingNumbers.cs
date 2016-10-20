using System;


namespace FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            Console.Write("{0:X}".PadRight(10,' ') + "|",a);
            Console.Write(Convert.ToString(a,2).PadLeft(10,'0') + "|");
            Console.Write("{0:f2}".PadLeft(10,' ') + "|",b);
            Console.WriteLine("{0:f3}".PadRight(10,' ') + "|",c);
            
        }
    }
}
