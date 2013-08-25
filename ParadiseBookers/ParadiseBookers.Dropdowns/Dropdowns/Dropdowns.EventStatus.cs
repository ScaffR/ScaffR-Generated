#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-20-2013
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

    public partial class Dropdowns : IDropdownProvider
    {
        /// <summary>
        /// Gets a list of countries.
        /// </summary>
        /// <returns>IEnumerable{SelectListItem}.</returns>
        public static IEnumerable<SelectListItem> EventStatus()
        {
            return new SelectList(Lists.EventStatusDictionary, "Value", "Key");
        }
    }
}