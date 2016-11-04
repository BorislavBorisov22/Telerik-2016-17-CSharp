    using System;



    class NumberOfPages
    {
        static void Main()
        {
            int digitsCount = int.Parse(Console.ReadLine());

            int totalPages = 0;
            int currPage = 1;
            while(digitsCount > 0)
            {
                int digitsRequired = 0;
                int tempPage = currPage;
                while (tempPage != 0)
                {
                    tempPage /= 10;
                    digitsRequired++;
                }


                if (digitsCount >= digitsRequired)
                {
                    totalPages++;
                    digitsCount -= digitsRequired;
                }
                currPage++;
            }

            Console.WriteLine(totalPages);
        }
    }

