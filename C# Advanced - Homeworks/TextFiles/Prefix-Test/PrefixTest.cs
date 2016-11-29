using System;
using System.IO;
using System.Text.RegularExpressions;

class PrefixTest
{
    //tester ,stortest test testing testosterone!
    // hypertest pretest testor -  preparation test test testful tester
    static void Main()
    {
        try
        {
            string filePath = @"..\..\PrefixTest.cs";
            string resultFilePath = @"..\..\result.txt";
            RemovePrefix(filePath, resultFilePath);
            Console.WriteLine("Prefixes deleted!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void RemovePrefix(string filePath, string resultFilePath)
    {
        var file = new StreamReader(filePath);
        var resultFile = new StreamWriter(resultFilePath);

        string currentLine = file.ReadLine();

        while (currentLine != null)
        {
            currentLine = Regex.Replace(currentLine, @"\b(test)(\w*)\b", "$2");
            resultFile.WriteLine(currentLine);

            currentLine = file.ReadLine();
        }


        file.Close();
        resultFile.Close();
    }
}

