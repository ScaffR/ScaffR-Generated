namespace DemoApplication.Infrastructure.Pipeline
{
    using System.Configuration.Provider;

    public abstract class Filter<T> : ProviderBase
    {
        public abstract bool Process(ref T data);
    }
}
