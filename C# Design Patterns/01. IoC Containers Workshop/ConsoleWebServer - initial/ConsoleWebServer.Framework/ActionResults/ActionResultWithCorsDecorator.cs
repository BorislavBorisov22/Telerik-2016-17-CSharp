using System;

namespace ConsoleWebServer.Framework.ActionResults
{ 
    public class ActionResultWithCorsDecorator : IActionResult
    {
        private readonly IActionResult actionResult;
        private string corsSettings;

        public ActionResultWithCorsDecorator(IActionResult actionResult, string corsSettings)
        {
            this.actionResult = actionResult;
            this.corsSettings = corsSettings;
        }

        public IHttpResponse GetResponse()
        {
            var response = this.actionResult.GetResponse();
            response.AddHeader("Access-Control-Allow-Origin", this.corsSettings);

            return response;
        }
    }
}
