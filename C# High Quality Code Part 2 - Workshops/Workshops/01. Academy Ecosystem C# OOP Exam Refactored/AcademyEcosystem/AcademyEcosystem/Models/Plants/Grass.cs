namespace AcademyEcosystem
{
    public class Grass : Plant, IPlant
    {
        private const int DefaultSize = 2;

        public Grass(IPoint location)
            : base(location, Grass.DefaultSize)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}
