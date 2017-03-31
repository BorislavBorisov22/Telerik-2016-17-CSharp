namespace Methods.CSharpPartTwoExam._04.GoshoCode
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    public class GoshoCode
    {
        public static void Main()
        {
            string searchedWord = Console.ReadLine();
            int linesCount = int.Parse(Console.ReadLine());

            var sentences = GetSentences(linesCount);
         
            BigInteger result = GetGoshoCodeFromSentences(sentences, searchedWord);
            Console.WriteLine(result);
        }

        private static BigInteger GetGoshoCodeFromSentences(IList<string> sentences, string searchedWord)
        {
            BigInteger result = 0;

            for (int i = 0; i < sentences.Count; i++)
            {
                string currentSentece = sentences[i].Trim();

                char lastSymbol = currentSentece[currentSentece.Length - 1];
                int indexOfWord = currentSentece.IndexOf(searchedWord);

                if (indexOfWord == -1)
                {
                    continue;
                }

                string targetSentencePart;
                if (lastSymbol == '.')
                {
                    targetSentencePart = GetSentenceAfterKeyWord(currentSentece, indexOfWord, searchedWord.Length);
                }
                else
                {
                    targetSentencePart = GetSentenceBeforeKeyWord(currentSentece, indexOfWord);
                }

                result += GetStringNumericalCode(targetSentencePart, searchedWord.Length);
            }

            return result;
        }

        private static BigInteger GetStringNumericalCode(string sentencePart, int searchedWordLength)
        {
            BigInteger resultCode = 0;
            for (int i = 0; i < sentencePart.Length - 1; i++)
            {
                char currentSymbol = sentencePart[i];

                if (currentSymbol != ' ')
                {
                    resultCode += (int)currentSymbol * searchedWordLength;
                }
            }

            return resultCode;
        }

        private static string GetSentenceAfterKeyWord(string sentence, int indexOfWord, int wordLength)
        {
            string targetPart = sentence.Substring(indexOfWord + wordLength);

            return targetPart;
        }

        private static string GetSentenceBeforeKeyWord(string sentence, int indexOfWord)
        {
            string targetPart = sentence.Substring(0, indexOfWord);

            return targetPart;
        }

        private static IList<string> GetSentences(int linesCount)
        {
            var sentences = new List<string>();
            var currentSentence = new StringBuilder();

            for (int i = 0; i < linesCount; i++)
            {
                string currentLine = Console.ReadLine();

                for (int symbolIndex = 0; symbolIndex < currentLine.Length; symbolIndex++)
                {
                    char currentSymbol = currentLine[symbolIndex];

                    currentSentence.Append(currentSymbol);

                    if (symbolIndex == currentLine.Length - 1 && currentSymbol != '.' && currentSymbol != '!')
                    {
                        currentSentence.Append(" ");
                    }

                    if (currentSymbol == '.' || currentSymbol == '!')
                    {
                        sentences.Add(currentSentence.ToString());
                        currentSentence.Clear();
                    }
                }
            }

            return sentences;
        }
    }
}
