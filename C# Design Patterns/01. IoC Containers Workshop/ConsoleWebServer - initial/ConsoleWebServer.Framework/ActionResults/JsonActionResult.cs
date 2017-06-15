namespace ConsoleWebServer.Framework.ActionResults
{
    using Newtonsoft.Json;
    using System.Net;

    public class JsonActionResult : BaseActionResult,  IActionResult
    {
        public readonly object model;

        public JsonActionResult(IHttpRequest request, object model)
            :base(request, model)
        {
            this.model = model;
        }

        protected override string GetBody()
        {
            return JsonConvert.SerializeObject(model);
        }

        protected override string GetContentType()
        {
            return "application/json";
        }

        protected override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }
    }
}
