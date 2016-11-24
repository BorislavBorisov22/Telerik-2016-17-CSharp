using System;
using System.Collections.Generic;

class WordDictionary
{
    static Dictionary<string, string> dict;
    static bool isDictionaryMade = false;

    static void Main()
    {
        OperateWithDictionary();
    }

    public static void OperateWithDictionary()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("1.To create a dictionary press");
                Console.WriteLine("2.To search in dictionary press");
                Console.WriteLine("3.To exit program press");
                string command = Console.ReadLine();
                if (command == "3")
                {
                    break;
                }
                else if (command == "1")
                {
                    Console.Write("Enter size of your dictionary(how many terms do you want ?) : ");
                    int sizeDict = int.Parse(Console.ReadLine());
                    if (sizeDict <= 0)
                    {
                        throw new ArgumentException("Dictionary size must be a positive number");
                    }
                    Console.WriteLine("Please enter {0} terms in the dictionary each on a separate row", sizeDict);
                    dict = MakeDictionary(sizeDict);
                    Console.WriteLine("Dictionary made successfully");
                    isDictionaryMade = true;

                }
                else if (command == "2")
                {
                    if (!isDictionaryMade)
                    {
                        throw new ArgumentException("No dictionary to search in");
                    }

                    Console.WriteLine("Please enter a term to search for:");
                    string term = Console.ReadLine();

                    if (!dict.ContainsKey(term))
                    {
                        throw new ArgumentException("No term found mathcing \"{0}\"", term);
                    }

                    Console.WriteLine("{0} -> {1}", term, dict[term]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }

    public static Dictionary<string, string> MakeDictionary(int sizeDictionary)
    {
        var dictionary = new Dictionary<string, string>();

        for (int i = 0; i < sizeDictionary; i++)
        {
            string[] currentLine = Console.ReadLine()
                .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string term = currentLine[0].Trim();
            string definitionOfTerm = currentLine[1].Trim();

            dictionary.Add(term, definitionOfTerm);
        }


        return dictionary;
    }
}

