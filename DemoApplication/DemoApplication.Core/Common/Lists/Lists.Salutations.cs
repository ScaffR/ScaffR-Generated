#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Common.Lists
{
    #region

    using System.Collections.Generic;

    #endregion

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
