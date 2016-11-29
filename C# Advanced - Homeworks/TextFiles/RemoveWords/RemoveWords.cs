using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


class RemoveWords
{
    static void Main()
    {
        try
        {
            string filePath = @"..\..\RemoveWords.cs";
            string wordsPath = @"..\..\words.txt";
            string resultFilePath = @"..\..\result.txt";

            RemoveWordsFromFile(filePath, wordsPath, resultFilePath);
            Console.WriteLine("Words from list have been removed!");

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void RemoveWordsFromFile(string filePath, string wordsPath, string resultFilePath)
    {
        StreamReader textFile = new StreamReader(filePath);
        StreamReader wordsFile = new StreamReader(wordsPath);
        StreamWriter resultFile = new StreamWriter(resultFilePath);


        List<string> words = new List<string>();
        //extract words from words file and close it
        using (wordsFile)
        {
            string word = wordsFile.ReadLine();

            while (word != null)
            {
                words.Add(word);
                word = wordsFile.ReadLine();
            }
        }
        

        string currentLine = textFile.ReadLine();
        //go through every line in the text file and remove all words from the list
        while (currentLine != null)
        {
            foreach (var word in words)
            {
                currentLine = Regex.Replace(currentLine, @"\b" + word + @"\b", string.Empty);
            }
            //currentLine = Regex.Replace(currentLine, @"\s{2,}", " ");
            resultFile.WriteLine(currentLine);
            currentLine = textFile.ReadLine();
        }
        
        textFile.Close();
        resultFile.Close();
    }
}

