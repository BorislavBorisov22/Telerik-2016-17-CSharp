using System;
using System.IO;

public class Lines
{
    public int Equal { get; set; }
    public int Different { get; set; }

    public Lines()
    {
        Equal = 0;
        Different = 0;
    }
}

class TextFilesComparer
{
    static void Main()
    {
        try
        {
            string firstFilePath = @"..\..\compareFile.txt";
            string secondFilePath = @"..\..\compareFile.txt";
            Lines linesFile = CalcEqualAndDiffLines(firstFilePath,secondFilePath);

            Console.WriteLine("Equal lines -> {0}",linesFile.Equal);
            Console.WriteLine("Different lines -> {0}",linesFile.Different);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Lines CalcEqualAndDiffLines(string firstFilePath, string secondFilePath)
    {
        var line = new Lines();

        StreamReader firstFile = new StreamReader(firstFilePath);
        StreamReader secondFile = new StreamReader(secondFilePath);

        string firstFileLine = firstFile.ReadLine();
        string secondFileLine = secondFile.ReadLine();

        while (firstFileLine != null)
        {
            if (firstFileLine == secondFileLine)
            {
                line.Equal += 1;
            }
            else
            {
                line.Different += 1;
            }

            firstFileLine = firstFile.ReadLine();
            secondFileLine = secondFile.ReadLine();
        }

        if (!(firstFileLine == null && secondFileLine == null))
        {
            throw new ArgumentException("Files do not have the same number of lines");
        }

        return line;

    }
}

