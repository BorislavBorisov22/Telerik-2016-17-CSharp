using System;
using System.Linq;

class SolveTasks
{
    private static void ReverseDigitsNumber()
    {
        Console.WriteLine("Please enter a number to be reversed (number must be positive)");
        double number;
        while (true)
        {
            number = double.Parse(Console.ReadLine());
            if (number > 0)
            {
                break;
            }

            Console.WriteLine("Number must be positive, please enter a valid number:");
        }

        string numberAsText = number.ToString();
        string reversedNumberAsText = string.Empty;

        for (int i = 0;i < numberAsText.Length; i++)
        {
            reversedNumberAsText = numberAsText[i] + reversedNumberAsText;
        }

        double reversedNumber = double.Parse(reversedNumberAsText);

        Console.WriteLine("Original number: {0}\nReversed number: {1}",number,reversedNumber);
    }
    private static void CalculateAverageOfSequence()
    {
        Console.WriteLine("Please enter a sequence of numbers:");
        int[] seq;

        while (true)
        {
             seq = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

            if (seq.Length != 0)
            {
                break;
            }


            Console.WriteLine("Sequence must have at least one element in it\nPlease enter a valid sequence");
            
        }


        double average = 0;
        double sumSequence = 0;
        for (int i = 0; i < seq.Length; i++)
        {
            sumSequence += seq[i];
        }

        average = sumSequence / seq.Length;
        Console.WriteLine("The average of the sequence is: {0:0.00}",average);



    }
    private static void SolveLinearEquation()
    {
        double a;
        while (true)
        {
            Console.WriteLine("Please enter paramater \"a\" value(must not be zero)");
            a = double.Parse(Console.ReadLine());
            
            if (a != 0)
            {
                break;
            }

            Console.WriteLine("Paremeter \"a\" should be different from zero\n Please enter a valid paramter");

        }
        Console.WriteLine("Please enter parameter \"b\" value");
        double b = double.Parse(Console.ReadLine());


        double x = b * -1 / a;

        Console.WriteLine("Tha value of \"x\" is: {0:0.00}",x); 
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please choose a problem to solve");
            Console.WriteLine("1 -> Reverse digits of a number");
            Console.WriteLine("2 -> Find average of a sequence of numbers");
            Console.WriteLine("3 -> Solve a linear equation of type ax + b = 0");
            Console.WriteLine("4 -> Exit program");

            string option = Console.ReadLine();
            if (option == "4")
            {
                Console.WriteLine("Thank you for using our problem solver! :)");
                break;
            }

            switch (option)
            {
                case "1":
                    ReverseDigitsNumber();
                    Console.WriteLine("----------------------------");
                    break;
                case "2":
                    CalculateAverageOfSequence();
                    Console.WriteLine("----------------------------");
                    break;
                case "3":
                    SolveLinearEquation();
                    Console.WriteLine("----------------------------");
                    break;
            }
        }
        
    }
}

