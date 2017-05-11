namespace AcademyEcosystem
{
    public interface IOrganism
    {
        bool IsAlive { get; }

        IPoint Location { get; }

        int Size { get; }

        void Update(int timeElapsed);
    }
}
