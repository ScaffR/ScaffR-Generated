#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns
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