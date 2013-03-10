namespace DemoApplication.Infrastructure.Storage.Providers
{
    using System.Web;
    using Interfaces.Storage;

    public class SessionStorageProvider : IStorageProvider
    {
        public T GetValue<T>(string key)
        {
            return (T)HttpContext.Current.Session[key];
        }

        public void SetValue(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}
