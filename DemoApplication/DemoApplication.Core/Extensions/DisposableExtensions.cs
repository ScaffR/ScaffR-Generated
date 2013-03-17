namespace DemoApplication.Core.Extensions
{
    #region

    using System;

    #endregion

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
