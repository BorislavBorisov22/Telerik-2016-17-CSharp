﻿namespace ConsoleWebServer.Application.Controllers
{
    using System;
    using System.Linq;

    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResults;
    using ConsoleWebServer.Framework.Interfaces;

    public class ApiController : Controller
    {
        public ApiController(IHttpRequest request, IActionResultFactory actionResultFactory)
            : base(request, actionResultFactory)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param });
        }

        public IActionResult GetDateWithCors(string domainName)
        {
            var requestReferer = string.Empty;
            if (this.Request.Headers.ContainsKey("Referer"))
            {
                requestReferer = this.Request.Headers["Referer"].FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException("Invalid referer!");
            }

            return this.ActionResultFactory.GetJsonActionResultWithCors(this.Request, new { date = DateTime.Now.ToString("yyyy-MM-dd"), moreInfo = "Data available for " + domainName }, domainName);
        }
    }
}