namespace ConsoleWebServer.Framework.Interfaces
{
    public interface IActionDescriptorFactory
    {
        IActionDescriptor CreateActionDescriptor(string uri);
    }
}
