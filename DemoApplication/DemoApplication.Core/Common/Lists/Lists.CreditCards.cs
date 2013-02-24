namespace DemoApplication.Core.Common.Lists
{
    using System.Collections.Generic;

    public static partial class Lists
    {
        public static readonly IDictionary<string, string> CreditCardDictionary = new Dictionary<string, string> 
        {
            {"", ""},
            {"Visa", "V"},
            {"Mastercard", "M"}
        };
    }
}
