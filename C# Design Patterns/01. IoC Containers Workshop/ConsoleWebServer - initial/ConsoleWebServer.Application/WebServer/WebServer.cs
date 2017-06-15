namespace ConsoleWebServer.Application
{
    using ConsoleWebServer.Application.Providers;
    using ConsoleWebServer.Framework;
    using System.Text;

    public class WebServer : IWebServer
    {
        private readonly IInputOutputProvider inputOutputProvider;
        private readonly IResponseProvider responseProvider;

        public WebServer(IInputOutputProvider inputOutputProvider, IResponseProvider responseProvider)
        {
            this.inputOutputProvider = inputOutputProvider;
            this.responseProvider = responseProvider;
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = this.inputOutputProvider.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                    this.inputOutputProvider.WriteLine(response.ToString());
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}