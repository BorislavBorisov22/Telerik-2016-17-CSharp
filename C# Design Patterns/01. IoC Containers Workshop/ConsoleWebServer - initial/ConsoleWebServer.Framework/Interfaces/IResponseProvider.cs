namespace ConsoleWebServer.Framework
{
    public interface IResponseProvider
    {
        IHttpResponse GetResponse(string requestAsString);
    }
}