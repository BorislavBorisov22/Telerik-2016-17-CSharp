using System;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int DefaultSize = 6;

        public Lion(string name, IPoint location)
            : base(name, location, Lion.DefaultSize)
        {
        }

        public int TryEatAnimal(IAnimal animal)
        {
            if (animal != null)
            {
                if (animal is Zombie || this.Size * 2 >= animal.Size)
                {
                    this.Size++;
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
