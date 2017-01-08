namespace StringBuilder.Extensions
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var testBuilder = new StringBuilder();
            testBuilder.Append("Some text");
            testBuilder.Append(" and some more text");

            // using the substring extension method that takes two arguments (int startIndex, int legnth)
            var result = testBuilder.Substring(5, 8);
            Console.WriteLine(result);

            // using the substring extension method that takes one argument( int startIdnex)
            var anotherResult = testBuilder.Substring(20);
            Console.WriteLine(anotherResult);
        } 
    }
}
