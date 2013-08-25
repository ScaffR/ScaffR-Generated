#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Collections.Generic;

namespace ParadiseBookers.Core.Common.Lists
{
    #region

    

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
