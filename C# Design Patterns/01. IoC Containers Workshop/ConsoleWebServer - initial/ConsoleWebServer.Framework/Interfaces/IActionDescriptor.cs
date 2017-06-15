namespace ConsoleWebServer.Framework
{
    public interface IActionDescriptor
    {
        string ActionName { get; }
        string ControllerName { get; }
        string Parameter { get; }

        string ToString();
    }
}