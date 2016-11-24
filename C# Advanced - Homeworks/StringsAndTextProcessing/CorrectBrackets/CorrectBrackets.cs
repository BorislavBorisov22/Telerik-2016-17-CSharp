using System;
using System.Text;
using System.Collections.Generic;


class CorrectBrackets
{
    public static bool CheckBrackets(string expression)
    {
        var storeBrackets = new Stack<char>();
      
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                storeBrackets.Push('(');
            }
            else if (expression[i] == ')')
            {
                if (storeBrackets.Count < 1 || storeBrackets.Pop() != '(')
                {
                    return false;
                }
            }
        }

        if (storeBrackets.Count > 0)
        {
            return false;
        }

        return true;
    }
    static void Main()
    {
        string expression = Console.ReadLine();
        bool areCorrect = CheckBrackets(expression);
        
        if (areCorrect)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }

       
    }
}

