using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalIncreasingSequence
{
    class MaxIncreasingSequence
    {
        static void Main()
        {
            int sizeArray = int.Parse(Console.ReadLine());

            long[] numbersArr = new long[sizeArray];
            for (int i = 0; i < sizeArray; i++)
            {
                long currNumber = long.Parse(Console.ReadLine());
                numbersArr[i]= currNumber;
            }

            int maxIncreasingSeq = 1;
            int currIncreasingSequence = 1;


            for (int i = 0; i < numbersArr.Length - 1; i++)
            {
                long currNumber = numbersArr[i];
                long nextNumber = numbersArr[i+1];

                if (currNumber < nextNumber)
                {
                    currIncreasingSequence++;
                    if (currIncreasingSequence > maxIncreasingSeq)
                    {
                        maxIncreasingSeq = currIncreasingSequence;
                    }
                }
                else
                {
                    if (currIncreasingSequence > maxIncreasingSeq)
                    {
                        maxIncreasingSeq = currIncreasingSequence;
                    }
                    currIncreasingSequence = 1;
                }

               
            }
            Console.WriteLine(maxIncreasingSeq);
        }
    }
}
