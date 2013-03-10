namespace DemoApplication.Core.Common.Lists
{
    using System.Collections.Generic;

    public static partial class Lists
    {
        public static readonly IDictionary<string, string> CountryDictionary = new Dictionary<string, string> 
        {
            {"United States", "US"},
            {"Canada", "CA"}
        };
    }
}
