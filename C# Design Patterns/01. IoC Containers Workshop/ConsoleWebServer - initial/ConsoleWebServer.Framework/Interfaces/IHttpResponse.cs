namespace ConsoleWebServer.Framework
{
    public interface IHttpResponse
    {
        string Body { get; }

        string ToString();

        void AddHeader(string name, string value);
    }
}