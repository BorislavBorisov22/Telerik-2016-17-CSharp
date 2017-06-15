namespace ConsoleWebServer.Framework
{
    using System;
    using System.Net;

    using ConsoleWebServer.Framework.Handlers;

    public class ResponseProvider : IResponseProvider
    {
        private readonly IHandler handler;
        private readonly IRequestParser requestParser;
        private readonly IHttpResponseFactory httpResponseFactory;

        public ResponseProvider(IHandler handler, IHttpResponseFactory responseFactory, IRequestParser requestParser)
        {
            this.httpResponseFactory = responseFactory;
            this.handler = handler;
            this.requestParser = requestParser;
        }

        public IHttpResponse GetResponse(string requestAsString)
        {
            IHttpRequest request;
            try
            {
                request = this.requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return this.httpResponseFactory.CreateHttpResponse(
                    new Version(1, 1),
                    HttpStatusCode.BadRequest,
                    ex.Message);
            }

            var response = this.handler.HandleRequest(request);
            return response;
        }   
    }
}