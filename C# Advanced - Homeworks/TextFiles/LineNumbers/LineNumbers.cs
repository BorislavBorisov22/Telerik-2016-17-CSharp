﻿using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        try
        {
            NumerateLinesInNewFile(@"..\..\LineNumbers.cs",@"..\..\result.txt");
            Console.WriteLine("File succesfully saved! :)");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void NumerateLinesInNewFile(string exisitngFilePath, string newFilePath)
    {
        var existingFile = new StreamReader(exisitngFilePath);
        var newFile = new StreamWriter(newFilePath);

        int linesCount = 1;
        using (existingFile)
        {
            string currentLine = existingFile.ReadLine();

            while (currentLine != null)
            {
                newFile.WriteLine("Line {0} -> {1}", linesCount, currentLine);
                linesCount++;
                currentLine = existingFile.ReadLine();
            }
        }

        newFile.Close();
    }
}

