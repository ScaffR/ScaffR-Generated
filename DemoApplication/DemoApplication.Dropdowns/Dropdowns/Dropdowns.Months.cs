#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns.Dropdowns
{
    #region

    using System.Web.Mvc;
    using Core.Common.Lists;

    #endregion

    public partial class Dropdowns
    {
        /// <summary>
        /// Monthses this instance.
        /// </summary>
        /// <returns>SelectList.</returns>
        public static SelectList Months()
        {
            return new SelectList(Lists.MonthDictionary, "Value", "Key");
        }
    }
}