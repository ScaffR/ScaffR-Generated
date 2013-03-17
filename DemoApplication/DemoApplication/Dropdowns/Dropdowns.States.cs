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

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Core.Common.Lists;

    #endregion

    public partial class Dropdowns
    {
        /// <summary>
        /// Gets the current states.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>IEnumerable{SelectListItem}.</returns>
        public static IEnumerable<SelectListItem> States(string code)
        {
            if (code == "US")
            {
                return new SelectList(Lists.UnitedStates, "Value", "Key");
            }
            if (code == "CA")
            {
                return new SelectList(Lists.CanadianProvinces, "Value", "Key");
            }
            return new List<SelectListItem>();
        }
    }
}