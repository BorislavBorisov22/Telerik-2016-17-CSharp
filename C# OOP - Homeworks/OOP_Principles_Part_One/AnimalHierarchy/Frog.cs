namespace AnimalHierarchy
{
    using System;

    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
            this.Type = Type.Frog;
        }

        public override void MakeSound()
        {
            Console.WriteLine("{0} said: \"Crock Crock!\"", this.Name);
        }
    }
}
