namespace Academy.CLI.Configuration
{
    public interface IConfiguratorProvider
    {
        bool IsTestEnvironment { get; }
    }
}
