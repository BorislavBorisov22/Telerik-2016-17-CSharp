using System;
using System.Text;

class EnterNumbers
{
    public static int ReadNumber(int start,int end)
    {
        int number = int.Parse(Console.ReadLine());

        if (number > start && number < end)
        {
            return number;
        }
        else
        {
            throw new ArgumentException("Exception");
        }
    }
    static void Main()
    {
        int numbersCount = 10;
        var result = new StringBuilder();
        try
        {
            int lastNumber = ReadNumber(1,100);
            result.Append("1 < ").AppendFormat("{0} < ",lastNumber);
            for (int i = 0; i < numbersCount - 1; i++)
            {
                int currNumber = ReadNumber(lastNumber,100);
                result.AppendFormat("{0} < ", currNumber);
                lastNumber = currNumber;
            }

            result.Append("100");

            Console.WriteLine(result.ToString().Trim());
        }
        catch(ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception");
        }
    }
}

