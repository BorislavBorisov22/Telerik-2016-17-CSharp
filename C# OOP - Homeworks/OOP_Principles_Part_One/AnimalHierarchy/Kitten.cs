namespace AnimalHierarchy
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age) 
            : base(name, age, Gender.Female)
        {
        }
    }
}
