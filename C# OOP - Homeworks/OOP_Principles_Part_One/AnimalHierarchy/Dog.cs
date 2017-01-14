namespace AnimalHierarchy
{
    using System;

    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
            this.Type = Type.Dog;
        }

        public override void MakeSound()
        {
            Console.WriteLine("{0} said: \"Bow Bow!\"", this.Name);
        }
    }
}
