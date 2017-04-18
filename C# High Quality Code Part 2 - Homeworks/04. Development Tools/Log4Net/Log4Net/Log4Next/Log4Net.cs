namespace Log4Net
{
    using log4net;
    using log4net.Config;
    using System;

    public class Log4Net
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Log4Net));

        public static void Main()
        {
            XmlConfigurator.Configure();

            try
            {
                var ivanchoPerson = new Person("Ivancho", 22);
                Log.Info($"Person {ivanchoPerson.Name} created successfully");

                var goshkoPerson = new Person("", -1);
                Log.Info($"Person {goshkoPerson.Name} created successfully!");
                Console.WriteLine(goshkoPerson.Name + " " + goshkoPerson.Age);
            }
            catch (Exception ex)
            {
                Log.Error("Error creating person => " + ex.Message);
            }
        }
    }
}
