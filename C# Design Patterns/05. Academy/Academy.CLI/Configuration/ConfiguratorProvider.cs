using System.Configuration;

namespace Academy.CLI.Configuration
{
    public class ConfiguratorProvider : IConfiguratorProvider
    {
        public bool IsTestEnvironment
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["IsTestEnvironment"]);
            }
        }
    }
}
