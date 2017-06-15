using ConsoleWebServer.Framework.ActionResults;
using System;
using System.Linq;
using System.Net;
using System.Reflection;

namespace ConsoleWebServer.Framework.Handlers
{
    public class OptionsHandler : Handler
    {
        public OptionsHandler(IHttpResponseFactory httpResponseFactory)
            : base(httpResponseFactory)
        {
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            return request.Method.ToLower() == "options";
        }

        protected override IHttpResponse Handle(IHttpRequest request)
        {
            var routes =
                   Assembly.GetEntryAssembly()
                       .GetTypes()
                       .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                       .Select(
                           x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult)) })
                       .SelectMany(
                           x =>
                           x.Methods.Select(
                               m =>
                               string.Format("/{0}/{1}/{{parameter}}", x.Name.Replace("Controller", string.Empty), m.Name)))
                       .ToList();

            return this.HttpResponseFactory.CreateHttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
        }
    }
}
