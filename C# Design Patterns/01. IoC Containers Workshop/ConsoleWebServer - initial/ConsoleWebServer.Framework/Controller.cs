namespace ConsoleWebServer.Framework
{
    using ConsoleWebServer.Framework.ActionResults;
    using ConsoleWebServer.Framework.Interfaces;

    public abstract class Controller
    {
        private readonly IActionResultFactory actionResultFactory;

        protected Controller(IHttpRequest request, IActionResultFactory actionResultFactory)
        {
            this.Request = request;
            this.actionResultFactory = actionResultFactory;
        }

        protected IActionResultFactory ActionResultFactory
        {
            get
            {
                return this.actionResultFactory;
            }
        }

        protected IHttpRequest Request { get; private set; }

        protected IActionResult Content(object model)
        {
            return this.actionResultFactory.GetContentActionResult(this.Request, model);
        }

        protected IActionResult Json(object model)
        {
            return this.actionResultFactory.GetJsonActionResult(this.Request, model);
        }

        protected IActionResult Redirect(string location)
        {
            return this.actionResultFactory.GetRedirectActionResult(this.Request, location);
        }
    }
}