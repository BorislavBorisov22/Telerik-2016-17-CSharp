namespace ControlFlowConditionalStatementsAndLoops._04.CSharpFundamentalsExam._02.GoingToAParty
{
    using System;

    public class GoingToAParty
    {
        public static void Main()
        {
            string djordjanoPath = Console.ReadLine();

            char partySymbol = '^';

            bool areLost = false;
            bool areAtTheParty = false;

            int index = 0;

            while (true)
            {
                char currentSymbol = djordjanoPath[index];
                int nextStepsCount = 0;

                if (currentSymbol == partySymbol)
                {
                    areAtTheParty = true;
                    break;
                }
                else if (IsBetweenSymbols(currentSymbol,'a', 'z'))
                {
                    nextStepsCount = currentSymbol - 'a' + 1;
                }
                else if (IsBetweenSymbols(currentSymbol, 'A', 'Z'))
                {
                    nextStepsCount = (currentSymbol - 'A' + 1) * -1;      
                }

                index += nextStepsCount;

                if (index < 0 || index >= djordjanoPath.Length)
                {
                    areLost = true;
                    break;
                }
            }

            if (areLost)
            {
                Console.WriteLine("Djor and Djano are lost at {0}!", index);
            }
            else if (areAtTheParty)
            {
                Console.WriteLine("Djor and Djano are at the party at {0}!", index);
            }
        }

        private static bool IsBetweenSymbols(char currentSymbol, char minSymbol, char maxSymbol)
        {
            if (minSymbol <= currentSymbol && currentSymbol <= maxSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
