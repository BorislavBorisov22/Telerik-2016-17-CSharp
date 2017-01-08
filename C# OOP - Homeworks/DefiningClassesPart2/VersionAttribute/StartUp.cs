namespace VersioAttribute
{
    using System;
    using VersionAttribute;

    [Version("1.00")]

    public class StartUp
    {
        public static void Main()
        {
            Type type = typeof(StartUp);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute version in allAttributes)
            {
                Console.WriteLine("Version {0}", version.Version);
            }
        }
    }
}