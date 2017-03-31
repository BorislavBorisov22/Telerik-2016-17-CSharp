namespace People
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var peopleFactory = new PeopleFactory();

            var person = peopleFactory.MakePerson(Gender.Male, 55);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            Console.WriteLine(person.Gender);
        }
    }
}
