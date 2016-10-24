using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntDoubleString
{
    class IntDoubleString
    {
        static void Main()
        {
            string inputType = Console.ReadLine();

            switch (inputType)
            {
                case "integer":
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine(number +1);
                    break;
                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    realNumber += 1;
                    Console.WriteLine("{0:f2}",realNumber);
                    break;
                case "text":
                    string text = Console.ReadLine();
                    text += "*";
                    Console.WriteLine(text);
                    break;

            }

        }
    }
}
