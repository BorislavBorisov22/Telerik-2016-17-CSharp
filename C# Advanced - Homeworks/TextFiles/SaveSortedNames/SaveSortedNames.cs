using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SaveSortedNames
{
    static void Main()
    {
        try
        {
            string filePath = @"..\..\..\UnsortedNames.txt";
            string sortedFilePath = @"..\..\..\SortedNames.txt";
            List<string> names = GetNamesFromFile(filePath);
            names = names.OrderBy(n => n).ToList();
            SaveSortedNamesInNewFile(names,sortedFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void SaveSortedNamesInNewFile(List<string> names,string sortedFilePath)
    {
        var file = new StreamWriter(sortedFilePath);

        using (file)
        {
            foreach (var name in names)
            {
                file.WriteLine(name);
            }
        }

        Console.WriteLine("Names succesfully sorted and saved!");
    }

    private static List<string> GetNamesFromFile(string filePath)
    {
        var namesFile = new StreamReader(filePath);
        var names = new List<string>();

        using (namesFile)
        {
            string currentLineFile = namesFile.ReadLine();

            while (currentLineFile != null)
            {
                names.Add(currentLineFile);
                currentLineFile = namesFile.ReadLine();
            }
        }
        
        return names;
    }
}

