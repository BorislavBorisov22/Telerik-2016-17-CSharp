namespace Methods
{
    using System;
    using Students;

    public class StartUp
    {     
        public static void Main()
        {
            Console.WriteLine(Method.CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(Method.NumberToDigit(5));
            
            Console.WriteLine(Method.FindMax(5, -1, 3, 2, 14, 2, 3));
            
            Method.PrintNumberTwoDigitsPrecision(1.3);
            Method.PrintNumberInPercentage(0.75);
            Method.PrintNumberRightAligned(2.30);

            double x1 = 3;
            double y1 = -1;
            double x2 = 3;
            double y2 = 2.5;
            Console.WriteLine(Method.CalcDistance(x1, y1, x2, y2));

            bool horizontal = Method.IsLineHorizontal(x1, x2);
            Console.WriteLine("Horizontal? " + horizontal);

            bool vertical = Method.IsLineVertical(y1, y2);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", DateTime.Parse("03/17/1992"));
            peter.OtherInfo = "From Sofia";

            Student stella = new Student("Stella", "Markova", DateTime.Parse("03/11/1993"));
            stella.OtherInfo = "From Vidin, gamer, high results.";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
