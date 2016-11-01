using System;


namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            char[] firstArray = Console.ReadLine().ToCharArray();
            char[] secondArray = Console.ReadLine().ToCharArray();
            string result = "";


            bool areEqual = true;

           for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    if (firstArray[i] > secondArray[i])
                    {
                        result = ">";
                    }
                    else
                    {
                        result = "<";
                    }
                    areEqual = false;
                    break;
                }
            }

           if (areEqual)
            {
                if (firstArray.Length > secondArray.Length)
                {
                    result = ">";

                }
                else if (firstArray.Length < secondArray.Length)
                {
                    result = "<";
                }
                else
                {
                    result = "=";
                }
            }

            Console.WriteLine(result);
        }
    }
}
