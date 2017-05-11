namespace AcademyEcosystem.Models.Contracts
{
    internal interface ILocationParser
    {
        IPoint ParsePoint(string pointString);
    }
}
