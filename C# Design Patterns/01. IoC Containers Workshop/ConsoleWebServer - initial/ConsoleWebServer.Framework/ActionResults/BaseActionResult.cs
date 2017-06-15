namespace ConsoleWebServer.Framework.ActionResults
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    public abstract class BaseActionResult : IActionResult
    {
        protected BaseActionResult(IHttpRequest request, object model)
        {
            this.Model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        protected List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        private IHttpRequest Request { get; set; }

        private object Model { get; set; }

        public IHttpResponse GetResponse()
        {
            var response = new HttpResponse(this.GetVersion(), this.GetStatusCode(),
                this.GetBody(), this.GetContentType());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }

        protected virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        protected virtual string GetBody()
        {
            return string.Empty;
        }

        protected virtual Version GetVersion()
        {
            return this.Request.ProtocolVersion;
        }

        protected virtual string GetContentType()
        {
            return HttpResponse.DefaultContentType;
        }
    }
}