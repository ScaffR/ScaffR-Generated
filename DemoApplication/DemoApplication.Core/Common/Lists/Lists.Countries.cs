namespace DemoApplication.Core.Common.Lists
{
    #region

    using System.Collections.Generic;

    #endregion

    public static partial class Lists
    {
        public static readonly IDictionary<string, string> CountryDictionary = new Dictionary<string, string> 
        {
            {"United States", "US"},
            {"Canada", "CA"}
        };
    }
}
