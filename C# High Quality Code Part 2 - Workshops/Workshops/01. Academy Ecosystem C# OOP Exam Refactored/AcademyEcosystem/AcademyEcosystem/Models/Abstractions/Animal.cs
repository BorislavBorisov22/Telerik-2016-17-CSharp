namespace AcademyEcosystem
{
    public abstract class Animal : Organism, IAnimal, IOrganism
    {
        protected Animal(string name, IPoint location, int size)
            : base(location, size)
        {
            this.Name = name;
            this.SleepRemaining = 0;
        }
     
        public AnimalState State { get; protected set; }

        public string Name { get; private set; }

        protected int SleepRemaining { get; set; }

        public virtual int GetMeatFromKillQuantity()
        {
            this.IsAlive = false;
            return this.Size;
        }

        public void GoTo(IPoint destination)
        {
            this.Location = destination;
            if (this.State == AnimalState.Sleeping)
            {
                this.Awake();
            }
        }

        public void Sleep(int time)
        {
            this.SleepRemaining = time;
            this.State = AnimalState.Sleeping;
        }

        public override void Update(int timeElapsed)
        {
            if (this.SleepRemaining == 0)
            {
                this.Awake();
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Name;
        }

        protected void Awake()
        {
            this.SleepRemaining = 0;
            this.State = AnimalState.Awake;
        }
    }
}
