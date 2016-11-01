using System;


namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main()
        {
            string word = Console.ReadLine().ToLower();
            var alphabetArr = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                char currLetter = word[i];
                for (int k = 0; k < alphabetArr.Length; k++)
                {
                    if (currLetter == alphabetArr[k])
                    {
                        Console.WriteLine(k);
                        break;
                    }
                }
            }
        }
    }
}
