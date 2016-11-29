using System;
using System.IO;

class ConcatenatorTextFiles
{
    static void Main()
    {
        try
        {
            string firstFilePath = @"..\..\forConcatenation.txt";
            string secondFilePath = @"..\..\ConcatenateTextFiles.cs";
            string resultFilePath = @"..\..\concatenatedFile.txt";
            ConcatenateFiles(firstFilePath, secondFilePath, resultFilePath);
            Console.WriteLine("Files concatenated successfully! :)");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ConcatenateFiles(string firstFilePath, string secondFilePath, string resultFilePath)
    {
        StreamWriter concatFile = new StreamWriter(resultFilePath);
        StreamReader firstFile = new StreamReader(firstFilePath);
        string line;
        using (firstFile)
        {
            line = firstFile.ReadLine();

            while (line != null)
            {
                concatFile.WriteLine(line);
                line = firstFile.ReadLine();
            }
        }

        StreamReader secondFile = new StreamReader(secondFilePath);

        using (secondFile)
        {
            line = secondFile.ReadLine();

            while (line != null)
            {
                concatFile.WriteLine(line);
                line = secondFile.ReadLine();
            }
        }
    }
}

