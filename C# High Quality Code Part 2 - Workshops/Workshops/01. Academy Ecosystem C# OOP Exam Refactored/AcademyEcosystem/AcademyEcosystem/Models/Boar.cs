using System;

namespace AcademyEcosystem
{
    public class Boar : Animal, IAnimal, ICarnivore, IHerbivore
    {
        private const int DefaultSize = 4;

        private int biteSize;

        public Boar(string name, IPoint location)
            : base(name, location, Boar.DefaultSize)
        {
            this.biteSize = 2;
        }

        public int EatPlant(IPlant plant)
        {
            if (plant != null)
            {
                ++this.Size;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }

        public int TryEatAnimal(IAnimal animal)
        {
            if (animal != null)
            {
                if (animal is Zombie)
                {
                    return animal.GetMeatFromKillQuantity();
                }

                if (this.Size * 2 >= animal.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
