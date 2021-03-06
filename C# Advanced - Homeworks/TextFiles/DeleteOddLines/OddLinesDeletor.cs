﻿using System;
using System.Collections.Generic;
using System.IO;

class OddLinesDeletor
{
    static void Main()
    {
        try
        {
            string filePath = @"..\..\testFile.txt";
            DeleteOddLines(filePath);
            Console.WriteLine("Odd lines deleted!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DeleteOddLines(string filePath)
    {
        var fileLines = new List<string>();
        StreamReader file = new StreamReader(filePath);

        string currentLine = file.ReadLine();
        int linesCount = 1;
        using (file)
        {
            //store all even lines from the original file
            while (currentLine != null)
            {
                if (linesCount % 2 == 0)
                {
                    fileLines.Add(currentLine);
                }
                currentLine = file.ReadLine();
                linesCount++;
            }
        }

        //rewrite the original file only with the even lines from the original file
        var resultFile = new StreamWriter(filePath);

        using (resultFile)
        {
            foreach (var line in fileLines)
            {
                resultFile.WriteLine(line);
            }
        }
        
    }
}

