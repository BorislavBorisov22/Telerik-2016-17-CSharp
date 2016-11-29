using System;
using System.IO;
using System.Text.RegularExpressions;


class WordReplacor
{
    //start some random text, start startup startnig start start start
    //start start some more random text .... ! start
    // starting finished started 

    static void Main()
    {
        try
        {
            string currentFilePath = @"..\..\input.txt";
            string resultFilePath = @"..\..\output.txt";
            string wordForReplace = "start";
            string replaceWord = "finish";

            ReplaceWholeWord(currentFilePath, resultFilePath, wordForReplace, replaceWord);
            Console.WriteLine("All words replaced and saved successfully! :)");
            
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReplaceWholeWord(string currentFilePath, string resultFilePath, string wordForReplace, string replaceWord)
    {
        StreamReader currentFile = new StreamReader(currentFilePath);
        StreamWriter resultFile = new StreamWriter(resultFilePath);

        string currentLine = currentFile.ReadLine();

        while (currentLine != null)
        {
            currentLine = Regex.Replace(currentLine,@"\b" + wordForReplace + @"\b", replaceWord);
            resultFile.WriteLine(currentLine);
            currentLine = currentFile.ReadLine();
        }


        currentFile.Close();
        resultFile.Close();
    }
}

