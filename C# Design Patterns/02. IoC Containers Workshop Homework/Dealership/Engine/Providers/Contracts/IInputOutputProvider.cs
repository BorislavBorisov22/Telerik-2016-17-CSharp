namespace Dealership.Engine.Providers.Contracts
{
    public interface IInputOutputProvider
    {
        void WriteLine(string message);

        void Write(string message);

        string ReadLine();
    }
}
