using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class CountWords
{
    static void Main()
    {
        try
        {
            string filePath = @"..\..\CountWords.cs";
            string wordsPath = @"..\..\words.txt";
            string resultFilePath = @"..\..\result.txt";

            CountWordsInFIle(filePath, wordsPath, resultFilePath);
            Console.WriteLine(@"Words counted and save in ""result.txt""");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }

    private static void CountWordsInFIle(string filePath, string wordsPath, string resultFilePath)
    {
        StreamReader file = new StreamReader(filePath);
        StreamReader wordsFile = new StreamReader(wordsPath);
        StreamWriter resultFile = new StreamWriter(resultFilePath);

        Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        var wordsList = new List<string>();
        //get all the words from the list and give them initial values of occurrence -> 0
        using (wordsFile)
        {
            string currWord = wordsFile.ReadLine();

            while (currWord != null)
            {
                wordsCount.Add(currWord, 0);
                wordsList.Add(currWord);
                currWord = wordsFile.ReadLine();
            }

        }

        //go thourgh the whole text file LineByLine and count occurence for each word from the list
        using (file)
        {
            string line = file.ReadLine();

            while (line != null)
            {
                foreach (var word in wordsList)
                {
                    
                    int matches = Regex.Matches(line, @"\b" + word + @"\b").Count;
                    wordsCount[word] += matches;
                    
                }
                line = file.ReadLine();
            }
        }

        //write result in a new file
        using (resultFile)
        {
            foreach (var word in wordsCount)
            {
                resultFile.WriteLine("{0} -> {1} times", word.Key, word.Value);
            }
        }
    }
}

