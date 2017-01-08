namespace LongestString
{
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] strings =
            {
                "apple",
                "strawberry",
                "pineapple",
                "cherry",
                "banana",
                "unconditional",
                "smile",
                "winter",
                "watermelon",
                "linq is awesome",
                "lambda expressions are awesome, too!",
                "events are not so awesome though"
            };

            int maxLenght = strings.Max(s => s.Length);
            string maxString = strings.Where(s => s.Length == maxLenght).First();
            System.Console.WriteLine("Longest string in the array has a length of {0}",maxLenght);
            System.Console.WriteLine("Longest string is -> {0}",maxString);
        }
    }
}
