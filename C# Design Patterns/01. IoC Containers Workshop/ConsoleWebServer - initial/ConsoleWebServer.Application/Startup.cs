using ConsoleWebServer.Application.Container;
using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Handlers;
using ConsoleWebServer.Framework.Interfaces;
using Ninject;
using System;

namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new WebServerModule());
            IWebServer webServer = kernel.Get<IWebServer>();
            webServer.Start();
        }
    }
}