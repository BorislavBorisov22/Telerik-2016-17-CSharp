using System;
using System.Net;

namespace ConsoleWebServer.Framework
{
    public interface IHttpResponseFactory
    {
        IHttpResponse CreateHttpResponse(
            Version httpVersion,
            HttpStatusCode statusCode,
            string body,
            string contentType = HttpResponse.DefaultContentType);
    }
}
