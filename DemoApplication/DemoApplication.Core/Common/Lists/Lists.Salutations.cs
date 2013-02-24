namespace DemoApplication.Core.Common.Lists
{
    using System.Collections.Generic;

    public static partial class Lists
    {
        public static readonly IDictionary<string, string> SalutationDirectory = new Dictionary<string, string> 
        {
            {"", ""},
            {"Dr.", "DR"},
            {"Hr.", "HR"},
            {"Mr.", "MR"},
            {"Mrs.", "MRS"},
            {"Ms.", "MS"},
            {"Sir.", "SIR"},
        };
    }
}
