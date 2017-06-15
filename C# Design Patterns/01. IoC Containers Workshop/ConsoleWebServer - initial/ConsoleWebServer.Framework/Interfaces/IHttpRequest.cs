namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Uri { get; }

        string Method { get; }

        IActionDescriptor Action { get; }

        Version ProtocolVersion { get; }

        IDictionary<string, ICollection<string>> Headers { get; }

        void AddHeader(string name, string value);
    }
}
