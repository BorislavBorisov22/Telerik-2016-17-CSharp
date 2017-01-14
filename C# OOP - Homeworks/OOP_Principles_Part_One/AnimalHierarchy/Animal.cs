namespace AnimalHierarchy
{
    using System;
    using System.Linq;
    using System.Text;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public Type Type { get; protected set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.ValidateName(value);

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                this.ValidateAge(value);

                this.age = value;
            }
        }

        public Gender Gender { get; private set; }

        public static string AnimalsAverageAge(Animal[] animals)
        {
            var result = new StringBuilder();

            var catsAverage = GetAverageOfType(animals, Type.Cat);
            var dogsAverage = GetAverageOfType(animals, Type.Dog);
            var frogsAverage = GetAverageOfType(animals, Type.Frog);

            result.AppendLine(string.Format("Cats average age: {0:f2}", catsAverage));
            result.AppendLine(string.Format("Dogs average age: {0:f2}", dogsAverage));
            result.AppendLine(string.Format("Frogs average age: {0:f2}", frogsAverage));

            return result.ToString().Trim();
        }

        public abstract void MakeSound();

        private static double GetAverageOfType(Animal[] animals, Type targetAnimalType)
        {
            var avgType = animals.Where(an => an.Type == targetAnimalType).Average(an => an.Age);
            return avgType;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Animal's name cannot be null or empty");
            }
        }

        private void ValidateAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentOutOfRangeException("Animal's age cannot be less than zero");
            }
        }
    }
}
