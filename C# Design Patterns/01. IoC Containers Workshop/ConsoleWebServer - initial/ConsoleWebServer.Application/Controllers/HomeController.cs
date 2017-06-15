namespace ConsoleWebServer.Application.Controllers
{
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResults;
    using ConsoleWebServer.Framework.Interfaces;

    public class HomeController : Controller
    {
        public HomeController(IHttpRequest request, IActionResultFactory actionResultFactory)
            : base(request, actionResultFactory)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            return this.ActionResultFactory.GetContentActionResultWithoutCachingDecorator(this.Request, "Live page with no caching");
        }

        public IActionResult LivePageForAjax(string param)
        {
            return this.ActionResultFactory.GetContentActionResultWithCorsAndNoCaching(this.Request, "Live page with no caching and CORS", "*");
        }

        public IActionResult Forum(string param)
        {
            return this.Redirect("https://telerikacademy.com/Forum/Home");
        }
    }
}