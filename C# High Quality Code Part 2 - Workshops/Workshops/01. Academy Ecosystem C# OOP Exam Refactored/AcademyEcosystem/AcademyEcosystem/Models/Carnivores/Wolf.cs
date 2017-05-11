using System;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int DefaultSize = 4;

        public Wolf(string name, IPoint location)
            : base(name, location, DefaultSize)
        {
        }

        public int TryEatAnimal(IAnimal animal)
        {
            if (animal != null)
            {
                if (animal is Zombie)
                {
                    return animal.GetMeatFromKillQuantity();
                }

                if (animal.State == AnimalState.Sleeping || animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
