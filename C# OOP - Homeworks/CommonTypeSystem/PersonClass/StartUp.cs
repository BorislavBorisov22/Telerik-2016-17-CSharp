namespace PersonClass
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // printing person wihtout having a name set
            var person = new Person("Draganka");
            Console.WriteLine("=======");
            Console.WriteLine(person);

            person.Age = 22;

            // printing peerson after having his name set
            Console.WriteLine(person);
        }
    }
}
