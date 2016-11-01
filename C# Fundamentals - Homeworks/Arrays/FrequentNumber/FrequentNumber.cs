using System;

namespace FrequentNumber
{
    class FrequentNumber
    {
        static void Main()
        {
            int sizeArray = int.Parse(Console.ReadLine());
            var numbersArr = new int[sizeArray];

            for (int i = 0; i < sizeArray; i++)
            {
                numbersArr[i] = int.Parse(Console.ReadLine());
            }

            int mostFrequentNumber = 0;
            int maxFrequency = 0;

            for (int i = 0; i < numbersArr.Length; i++)
            {
                int currNumber = numbersArr[i];
                int frequencyNumber = 0;
                for (int k = 0; k < numbersArr.Length; k++)
                {
                    if (numbersArr[k] == currNumber)
                    {
                        frequencyNumber++;
                    }
                }

                if (frequencyNumber > maxFrequency)
                {
                    maxFrequency = frequencyNumber;
                    mostFrequentNumber = currNumber;
                }
            }

            Console.WriteLine("{0} ({1} times)",mostFrequentNumber,maxFrequency);
            
        }
    }
}
