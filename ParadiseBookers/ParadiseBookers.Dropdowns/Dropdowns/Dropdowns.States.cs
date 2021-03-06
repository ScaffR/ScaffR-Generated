#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Collections.Generic;
using System.Web.Mvc;
using ParadiseBookers.Core.Common.Lists;

namespace ParadiseBookers.Dropdowns.Dropdowns
{
    #region

    

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