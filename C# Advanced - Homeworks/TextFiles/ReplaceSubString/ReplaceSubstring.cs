using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplacorSubstring
{
    static void Main()
    {
        try
        {
            string originalFilePath = @"..\..\input.txt";
            string resultFilePath = @"..\..\output.txt";

            ReplaceSubstring(originalFilePath, resultFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReplaceSubstring(string originalFilePath, string resultFilePath)
    {
        string wordToReplace = "start";
        string replaceWord = "finish";

        StreamReader originalFile = new StreamReader(originalFilePath);
        StreamWriter resultFile = new StreamWriter(resultFilePath);

        string currentLine = originalFile.ReadLine();
        
        while (currentLine != null)
        {
            currentLine = currentLine.Replace(wordToReplace, replaceWord);
            resultFile.WriteLine(currentLine);
            currentLine = originalFile.ReadLine();
        }


        Console.WriteLine("Words replaced and saved successfully");
        originalFile.Close();
        resultFile.Close();
    }
}

