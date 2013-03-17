namespace DemoApplication.Infrastructure.Pipeline
{
    #region

    using System.Configuration.Provider;

    #endregion

    public abstract class Filter<T> : ProviderBase
    {
        public abstract bool Process(ref T data);
    }
}
