namespace DemoApplication.Core.Interfaces.Storage
{
    public interface IStorageProvider
    {
        T GetValue<T>(string key);

        void SetValue(string key, object value);
    }
}
