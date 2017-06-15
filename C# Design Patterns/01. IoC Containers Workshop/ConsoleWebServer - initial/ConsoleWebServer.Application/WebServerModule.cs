using ConsoleWebServer.Application.Interceptors;
using ConsoleWebServer.Application.Providers;
using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.ActionResults;
using ConsoleWebServer.Framework.Handlers;
using ConsoleWebServer.Framework.Interfaces;
using Ninject;

using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleWebServer.Application.Container
{
    public class WebServerModule : NinjectModule
    {
        public const string HeadHandlerName = "HeadHandler";
        public const string OptionsHandlerName = "OptionsHandler";
        public const string StaticFileHandlerName = "StaticFileHandler";
        public const string ControllerHandlerName = "ControllerHandler";

        public const string ContentActionResultName = "ContentActionResult";
        public const string JsonActionResultName = "JsonActionResult";
        public const string RedirectActionResultName = "RedirectActionResult";
        public const string ContentActionResultWithoutCachingDecoratorName = "ContentActionResultWithoutCachingDecorator";
        public const string ActionResultWithCorsName = "ActionResultWithCors";

        public const string ActionResultConstructorArgument = "actionResult";
        public const string CorseSettingsConstructorArgument = "corsSettings";

        public override void Load()
        {
            this.Bind<IWebServer>().To<WebServer>();
            this.Bind<IResponseProvider>().To<ResponseProvider>();

            this.Bind<IHandler>().To<HeadHandler>().Named(HeadHandlerName);
            this.Bind<IHandler>().To<HeadHandler>().Named(OptionsHandlerName);
            this.Bind<IHandler>().To<HeadHandler>().Named(StaticFileHandlerName);
            this.Bind<IHandler>().To<HeadHandler>().Named(ControllerHandlerName);
            this.Bind<IHandler>().ToMethod(context =>
            {
                var headHandler = context.Kernel.Get<IHandler>(HeadHandlerName);
                var optionsHandler = context.Kernel.Get<IHandler>(OptionsHandlerName);
                var fileHandler = context.Kernel.Get<IHandler>(StaticFileHandlerName);
                var controllerHandler = context.Kernel.Get<IHandler>(ControllerHandlerName);

                headHandler.SetSuccessor(optionsHandler);
                optionsHandler.SetSuccessor(fileHandler);
                fileHandler.SetSuccessor(controllerHandler);

                return headHandler;
            })
            .WhenInjectedInto<IResponseProvider>();

            this.Bind<IInputOutputProvider>().To<ConsoleInputOutputProvider>();
            this.Bind<IActionDescriptor>().To<ActionDescriptor>();
            this.Bind<IHttpResponse>().To<HttpResponse>();
            this.Bind<IHttpRequest>().To<HttpRequest>();
            this.Bind<IRequestParser>().To<RequestParser>();

            this.Bind<IActionResult>().To<ContentActionResult>().Named(ContentActionResultName);
            this.Bind<IActionResult>().To<JsonActionResult>().Named(JsonActionResultName);
            this.Bind<IActionResult>().To<RedirectActionResult>().Named(RedirectActionResultName);
            this.Bind<IActionResult>().To<ActionResultWithCorsDecorator>().Named(ActionResultWithCorsName);

            //this.Bind<ActionResultWithNoCachingInterceptor>().ToSelf();
           // this.Bind<IActionResult>().To<ContentActionResult>().Named(ContentActionResultWithoutCachingDecoratorName).Intercept().With<ActionResultWithNoCachingInterceptor>();

            this.Bind<IActionResult>().ToMethod(context =>
            {
                List<IParameter> contextParams = context.Parameters.ToList();

                var corsSettings = contextParams[2];
                var request = contextParams[0];
                var model = contextParams[1];

                return context.Kernel.Get<IActionResult>(ActionResultWithCorsName,
                    corsSettings, new ConstructorArgument(ActionResultConstructorArgument,
                    context.Kernel.Get<IActionResult>(JsonActionResultName, contextParams[0], contextParams[1])));

            }).NamedLikeFactoryMethod((IActionResultFactory actionResultFactory) => actionResultFactory.GetJsonActionResultWithCors(null, null, null));

            this.Bind<IActionResult>().ToMethod(context =>
            {
                List<IParameter> contextParams = context.Parameters.ToList();
                var request = contextParams[0];
                var model = contextParams[1];
                var corsSettings = contextParams[2];

                return context.Kernel.Get<IActionResult>(ActionResultWithCorsName, corsSettings,
                    new ConstructorArgument(ActionResultConstructorArgument,
                    this.Kernel.Get<IActionResult>(ContentActionResultWithoutCachingDecoratorName, request, model)));
            }).NamedLikeFactoryMethod((IActionResultFactory actionResultFactory) => actionResultFactory.GetContentActionResultWithCorsAndNoCaching(null, null, null));

            this.Bind<IHttpResponseFactory>().ToFactory().InSingletonScope();
            this.Bind<IHttpRequestFactory>().ToFactory().InSingletonScope();
            this.Bind<IActionResultFactory>().ToFactory().InSingletonScope();
            this.Bind<IActionDescriptorFactory>().ToFactory().InSingletonScope();

            this.Bind<Func<IHttpRequest, Controller>>()
              .ToMethod(context =>
              (request) =>
              {
                  string controllerClassName = request.Action.ControllerName + "Controller";
                  Type type =
                      Assembly.GetEntryAssembly()
                          .GetTypes()
                          .FirstOrDefault(
                              x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));

                  if (type == null)
                  {
                      throw new HttpNotFoundException(
                          string.Format("Controller with name {0} not found!", controllerClassName));
                  }

                  Controller instance = (Controller)context.Kernel.Get(type,
                      new ConstructorArgument("request", request),
                      new ConstructorArgument("responseProvider", context.Kernel.Get<IActionResultFactory>()));
                  return instance;
              }).InSingletonScope();
        }
    }
}
