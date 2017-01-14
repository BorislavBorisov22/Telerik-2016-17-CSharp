namespace AnimalHierarchy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Animal[] animals =
            {
                new Tomcat("Izdislav", 2),
                new Tomcat("Strahil", 12),
                new Tomcat("Tom", 1),
                new Kitten("Maca", 22),
                new Kitten("Maca", 3),
                new Kitten("Mariika", 4),
                new Kitten("Strahilka", 9),
                new Dog("Sharo", 3, Gender.Male),
                new Dog("Rex", 5, Gender.Male),
                new Dog("Tsvetka", 3, Gender.Female),
                new Dog("Veska", 9, Gender.Female),
                new Dog("Valdes", 4, Gender.Male),
                new Frog("Princess", 5, Gender.Female),
                new Frog("Toshko", 1, Gender.Male),
                new Frog("Prince", 4, Gender.Male),
            };

            animals.ToList().ForEach(a => a.MakeSound());
            Console.WriteLine(Animal.AnimalsAverageAge(animals));
        }
    }
}
