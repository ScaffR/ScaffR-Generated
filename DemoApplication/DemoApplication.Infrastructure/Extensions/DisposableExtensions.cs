namespace DemoApplication.Infrastructure.Extensions
{
    using System;

    public static class DisposableExtensions
    {
        public static bool TryDispose(this IDisposable item)
        {
            if (item == null) return false;
            item.Dispose();
            return true;
        }
    }
}
