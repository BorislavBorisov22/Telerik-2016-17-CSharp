using System;
using System.IO;
using System.Security;

class ReadFileContents
{
    static void Main()
    {
        Console.Write("enter file name (full path): ");
        string input = Console.ReadLine();
        try
        {
            string fileText = File.ReadAllText(input);
            Console.WriteLine(fileText);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Path must not be empty");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Path length is too long");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File was not found in the selected directory");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid directory in path");
        }
        catch (IOException)
        {
            Console.WriteLine("An error occured during opening the file");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("No permission to desired file");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is not in a valid format");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You do not have persmission to access this file");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid path format");
        }
        

    }

   
}

