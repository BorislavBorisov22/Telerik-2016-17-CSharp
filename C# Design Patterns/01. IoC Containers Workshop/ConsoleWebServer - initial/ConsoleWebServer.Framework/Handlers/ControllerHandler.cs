using System;
using System.Net;

namespace ConsoleWebServer.Framework.Handlers
{
    public class ControllerHandler : Handler
    {
        private readonly IActionInvoker actionInvoker;
        private readonly Func<IHttpRequest, Controller> controllerFactory;

        public ControllerHandler(IHttpResponseFactory httpResponseFactory, Func<IHttpRequest, Controller> controllerFactory, IActionInvoker actionInvoker)
            : base(httpResponseFactory)
        {
            this.actionInvoker = actionInvoker;
            this.controllerFactory = controllerFactory;
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            return request.ProtocolVersion.Major < 3;
        }

        protected override IHttpResponse Handle(IHttpRequest request)
        {
            IHttpResponse response;
            try
            {
                var controller = this.controllerFactory(request);
                var actionResult = this.actionInvoker.InvokeAction(controller, request.Action);
                response = actionResult.GetResponse();
            }
            catch (HttpNotFoundException exception)
            {
                response = this.HttpResponseFactory.CreateHttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
            }
            catch (Exception exception)
            {
                response = this.HttpResponseFactory.CreateHttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
            }

            return response;
        }
    }
}
