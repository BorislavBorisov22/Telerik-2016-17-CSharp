using System.Net;

namespace ConsoleWebServer.Framework.Handlers
{
    public abstract class Handler : IHandler
    {
        private readonly IHttpResponseFactory httpResponseFactory;

        public Handler(IHttpResponseFactory httpResponseFactory)
        {
            this.httpResponseFactory = httpResponseFactory;
        }

        private IHandler Successor { get; set; }

        protected IHttpResponseFactory HttpResponseFactory
        {
            get
            {
                return this.httpResponseFactory;
            }
        }

        public void SetSuccessor(IHandler successor)
        {
            this.Successor = successor;
        }

        public IHttpResponse HandleRequest(IHttpRequest request)
        {
            if (this.CanHandle(request))
            {
                return this.HandleRequest(request);
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleRequest(request);
            }

            return this.httpResponseFactory.CreateHttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, "Request cannot be handled.");
        }

        protected abstract bool CanHandle(IHttpRequest request);

        protected abstract IHttpResponse Handle(IHttpRequest request);
    }
}
