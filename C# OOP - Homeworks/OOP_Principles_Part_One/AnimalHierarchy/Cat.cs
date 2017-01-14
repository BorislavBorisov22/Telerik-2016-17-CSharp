namespace AnimalHierarchy
{
    using System;

    public abstract class Cat : Animal, ISound
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
            this.Type = Type.Cat;
        }

        public override void MakeSound()
        {
            Console.WriteLine("{0} said: \"Meow Meow!\"", this.Name);
        }
    }
}
