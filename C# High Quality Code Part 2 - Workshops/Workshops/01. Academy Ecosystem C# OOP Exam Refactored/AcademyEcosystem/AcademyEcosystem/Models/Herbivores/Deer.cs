namespace AcademyEcosystem
{
    public class Deer : Animal, IHerbivore
    {
        private int biteSize;

        public Deer(string name, IPoint location)
            : base(name, location, 3)
        {
            this.biteSize = 1;
        }

        public override void Update(int timeElapsed)
        {
            if (this.State == AnimalState.Sleeping)
            {
                if (timeElapsed >= this.SleepRemaining)
                {
                    this.Awake();
                }
                else
                {
                    this.SleepRemaining -= timeElapsed;
                }
            }

            base.Update(timeElapsed);
        }

        public int EatPlant(IPlant p)
        {
            if (p != null)
            {
                return p.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
    }
}
