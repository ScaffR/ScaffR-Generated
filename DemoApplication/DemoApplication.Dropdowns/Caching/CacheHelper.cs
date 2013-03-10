namespace DemoApplication.Dropdowns.Caching
{
    using System;
    using System.Web;


    public static class DropdownCacheHelper
        {
            /// <summary>
            /// Insert value into the cache using
            /// appropriate name/value pairs
            /// </summary>
            /// <typeparam name="T">Type of cached item</typeparam>
            /// <param name="o">Item to be cached</param>
            /// <param name="key">Name of item</param>
            /// <param name="minutes"></param>
            public static void Add(bool o, string key, int minutes)
            {
                // NOTE: Apply expiration parameters as you see fit.
                // In this example, I want an absolute
                // timeout so changes will always be reflected
                // at that time. Hence, the NoSlidingExpiration.
                HttpContext.Current.Cache.Insert(
                    key,
                    o,
                    null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration,
                    new TimeSpan(0, 0, minutes));
            }

            /// <summary>
            /// Remove item from cache
            /// </summary>
            /// <param name="key">Name of cached item</param>
            public static void Clear(string key)
            {
                HttpContext.Current.Cache.Remove(key);
            }

            /// <summary>
            /// Check for item in cache
            /// </summary>
            /// <param name="key">Name of cached item</param>
            /// <returns></returns>
            public static bool Exists(string key)
            {
                return HttpContext.Current.Cache[key] != null;
            }

            public static bool Get(string key)
            {
                try
                {
                    return (bool)HttpContext.Current.Cache[key];
                }
                catch
                {
                    return false;
                }
            }
        }
    

}
