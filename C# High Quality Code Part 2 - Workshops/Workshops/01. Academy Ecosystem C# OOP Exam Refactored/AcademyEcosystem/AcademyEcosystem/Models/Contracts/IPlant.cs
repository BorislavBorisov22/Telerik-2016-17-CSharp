namespace AcademyEcosystem
{
    public interface IPlant : IOrganism
    {
        int GetEatenQuantity(int biteSize);

        string ToString();
    }
}