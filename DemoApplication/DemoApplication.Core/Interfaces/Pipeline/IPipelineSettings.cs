namespace DemoApplication.Core.Interfaces.Pipeline
{
    #region

    using System.Configuration;

    #endregion

    public interface IPipelineSettings
    {
        string ProcessorType { get; }
        ProviderSettingsCollection Filters { get; }
    }
}