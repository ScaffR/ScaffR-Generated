namespace DemoApplication.Core.Common.Lists
{
    #region

    using System.Collections.Generic;

    #endregion

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
