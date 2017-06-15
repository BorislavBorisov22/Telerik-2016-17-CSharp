namespace ConsoleWebServer.Framework.ActionResults
{
    public class ContentActionResult : BaseActionResult, IActionResult
    {
        public readonly object model;

        public ContentActionResult(IHttpRequest request, object model)
            :base(request, model)
        {
            this.model = model;
        }
     

        protected override string GetBody()
        {
            return this.model.ToString();
        }
    }
}