namespace ControlFlowConditionalStatementsAndLoops
{
    using System;
    using System.Collections.Generic;

    public class Looper
    {
        public void SomeMethod()
        {
            int[] numbersArr = new int[100];

            int expectedValue = 666;
            bool isFound = false;

            for (int i = 0; i < numbersArr.Length; i++)
            {
                int currentNumber = numbersArr[i];

                if (i % 10 == 0 && currentNumber == expectedValue)
                {
                    isFound = true;
                }

                Console.WriteLine(numbersArr[i]);
            }


            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
