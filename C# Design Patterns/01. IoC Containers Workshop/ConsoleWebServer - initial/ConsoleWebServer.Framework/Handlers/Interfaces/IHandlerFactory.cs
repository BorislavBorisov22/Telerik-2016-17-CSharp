namespace ConsoleWebServer.Framework.Handlers
{
    public interface IHandlerFactory
    {
        IHandler CreateAndComposeHandler();
    }
}