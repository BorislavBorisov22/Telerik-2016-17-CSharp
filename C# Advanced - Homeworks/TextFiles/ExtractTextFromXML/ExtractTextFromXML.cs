using System;
using System.IO;
using System.Text;

class ExtractTextFromXML
{
    static void Main()
    {
        try
        {
            string filePath = @"..\..\input.txt";
            string resultFilePath = @"..\..\result.txt";
            ExtractText(filePath, resultFilePath);
            Console.WriteLine("text extracted!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ExtractText(string filePath, string resultFilePath)
    {
        StringBuilder text = new StringBuilder();
        StreamReader file = new StreamReader(filePath);
        StreamWriter resultFile = new StreamWriter(resultFilePath);
        string currentLine = file.ReadLine();

        bool inTag = false;
        while (currentLine != null)
        {
            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentSymbol = currentLine[i];
                if (!inTag && currentSymbol == '<')
                {
                    inTag = true;
                }
                else if (inTag && currentSymbol == '>')
                {
                    inTag = false;
                }
                else if (!inTag)
                {
                    text.Append(currentSymbol);
                }
            }
            if (text.Length > 0)
            {
                resultFile.WriteLine(text);
            }
            text.Clear();
            currentLine = file.ReadLine();
        }


        file.Close();
        resultFile.Close();
    }
}

