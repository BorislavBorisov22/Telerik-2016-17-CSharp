using System;

class SquareRoot
{
    public static double ParseDouble(string input)
    {
        double number = double.Parse(input);

        if (number < 0)
        {
            throw new ArgumentException("Invalid number");
        }

        return number;
    }
    static void Main()
    {

        string input = Console.ReadLine();

        try
        {
            double number = ParseDouble(input);
            Console.WriteLine("{0:0.000}",number);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine(aex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }


}

