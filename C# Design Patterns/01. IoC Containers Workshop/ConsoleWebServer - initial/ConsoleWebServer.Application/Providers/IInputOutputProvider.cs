namespace ConsoleWebServer.Application.Providers
{
    public interface IInputOutputProvider
    {
        void WriteLine(string message);

        string ReadLine();
    }
}
