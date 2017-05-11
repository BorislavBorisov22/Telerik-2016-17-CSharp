namespace AcademyEcosystem
{
    public interface IAnimal : IOrganism
    {
        string Name { get; }

        AnimalState State { get; }

        int GetMeatFromKillQuantity();

        void GoTo(IPoint destination);

        void Sleep(int time);

        string ToString();
    }
}