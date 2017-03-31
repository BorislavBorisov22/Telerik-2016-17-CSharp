namespace ControlFlowConditionalStatementsAndLoops._04.CSharpFundamentalsExam._03.SecretMessage
{
    using System;
    using System.Text;

    public class SecretMessage
    {
        public static void Main()
        {
            string decodedText = string.Empty;
            int linesCount = 1;

            while (true)
            {
                string firstLineInput = Console.ReadLine();

                if (firstLineInput == "end")
                {
                    break;
                }

                int startIndex = int.Parse(firstLineInput);
                int endIndex = int.Parse(Console.ReadLine());

                string currText = Console.ReadLine();

                if (startIndex < 0)
                {
                    startIndex = currText.Length + startIndex;
                }

                if (endIndex < 0)
                {
                    endIndex = currText.Length + endIndex;
                }

                int loopStep = linesCount % 2 == 0 ? 4 : 3;

                decodedText += GetEveryNthSymbolsInText(currText, startIndex, endIndex, loopStep);

                linesCount++;
            }

            Console.WriteLine(decodedText);
        }

        private static string GetEveryNthSymbolsInText(string text, int startIndex, int endIndex, int step)
        {
            string result = string.Empty;

            for (int i = startIndex; i <= endIndex; i += step)
            {
                result += text[i];
            }

            return result;
        }
    }
}