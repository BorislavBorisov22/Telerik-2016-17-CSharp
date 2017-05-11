namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int MeatWhenEaten = 10;
        private const int DefaultSize = 10;

        public Zombie(string name, IPoint location) 
            : base(name, location, Zombie.DefaultSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            this.IsAlive = true;
            return this.Size;
        }
    }
}
