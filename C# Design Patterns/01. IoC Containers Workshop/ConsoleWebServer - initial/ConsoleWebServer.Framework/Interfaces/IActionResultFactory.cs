using ConsoleWebServer.Framework.ActionResults;

namespace ConsoleWebServer.Framework.Interfaces
{
    public interface IActionResultFactory
    {
        IActionResult GetContentActionResult(IHttpRequest request, object model);

        IActionResult GetJsonActionResult(IHttpRequest request, object model);

        IActionResult GetRedirectActionResult(IHttpRequest request, object model);

        IActionResult GetJsonActionResultWithCors(IHttpRequest request, object model, string corsSettings);

        IActionResult GetContentActionResultWithoutCachingDecorator(IHttpRequest request, object model);

        IActionResult GetContentActionResultWithCorsAndNoCaching(IHttpRequest request, object model, string corsSettings);
    }
}
