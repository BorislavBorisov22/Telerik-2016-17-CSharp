using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        try
        {
            string filePath = @"..\..\OddLines.cs";
            PrintFileOddLines(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintFileOddLines(string filePath)
    {
        int linesCount = 1;
        var file = new StreamReader(filePath);

        using (file)
        {
            string currentLine = file.ReadLine();

            while (currentLine != null)
            {
                if (linesCount % 2 == 1)
                {
                    Console.WriteLine(currentLine);
                }
                linesCount++;
                currentLine = file.ReadLine();
            }
        }
    }
}

