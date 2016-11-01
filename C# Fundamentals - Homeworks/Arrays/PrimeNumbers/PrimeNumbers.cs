using System;


namespace PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main()
        {
            int range = int.Parse(Console.ReadLine());

            bool[] allNumbers = new bool[range + 1];

            //making all numbers from 2 to range+1 be true(considered prime at first)

            for (int CurrNumber = 2; CurrNumber < allNumbers.Length; CurrNumber++)
            {
                allNumbers[CurrNumber] = true;
            }
            // starting from the smallest number with value true in the bool matrix
            int currPrime = 2;
            while (true)
            {
                bool nextPrimeExists = false;

                for (int currNumber = currPrime + currPrime; currNumber < allNumbers.Length; currNumber += currPrime)
                {
                    allNumbers[currNumber] = false;
                }

                //checking for the next closest number with value true to be our starting prime number
                for (int i = currPrime + 1; i < allNumbers.Length; i++)
                {
                    if (allNumbers[i] == true)
                    {
                        currPrime = i;
                        nextPrimeExists = true;
                        break;
                    }
                }
                if (!nextPrimeExists)
                {
                    break;
                }
            }

            int maxPrime = 0;
            for (int i = allNumbers.Length - 1; i >= 0; i--)
            {
                if (allNumbers[i] == true)
                {
                    maxPrime = i;
                    break;
                }
            }
            Console.WriteLine(maxPrime);
        }
    }
}
