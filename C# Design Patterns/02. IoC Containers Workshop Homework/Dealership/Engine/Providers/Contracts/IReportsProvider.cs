namespace Dealership.Engine.Providers.Contracts
{
    public interface IReportsProvider
    {
        void AddReport(string report);

        void PrintReports(IInputOutputProvider inputOutputProvider);
    }
}
