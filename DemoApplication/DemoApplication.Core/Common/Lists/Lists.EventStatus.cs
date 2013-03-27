#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-20-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Common.Lists
{
    #region

    using System.Collections.Generic;

    #endregion

    public static partial class Lists
    {
        public static readonly IDictionary<string, string> EventStatusDictionary = new Dictionary<string, string> 
     
        {
            {"Info", "Info"},
            {"Error", "Error"},
            {"Warning", "Warning"},
            {"Success", "Success"},
            {"Debug", "Debug"},
            {"Fatal", "Fatal"}
        };
    }
}
