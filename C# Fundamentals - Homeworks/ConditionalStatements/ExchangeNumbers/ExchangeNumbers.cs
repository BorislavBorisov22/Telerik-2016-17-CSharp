using System;


namespace ExchangeNumbers
{
    class ExchangeNumbers
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondnumber = double.Parse(Console.ReadLine());

            if (firstNumber > secondnumber)
            {
                secondnumber += firstNumber;
                firstNumber = secondnumber - firstNumber;
                secondnumber -= firstNumber;
            }
            Console.WriteLine(firstNumber + " " + secondnumber);
        }
    }
}
