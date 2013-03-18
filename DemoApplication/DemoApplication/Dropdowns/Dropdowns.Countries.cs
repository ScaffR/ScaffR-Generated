#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Core.Common.Lists;

    #endregion

    public partial class Dropdowns : IDropdownProvider
    {
        /// <summary>
        /// Gets a list of countries.
        /// </summary>
        /// <returns>IEnumerable{SelectListItem}.</returns>
        public static IEnumerable<SelectListItem> Countries()
        {
            return new SelectList(Lists.CountryDictionary, "Value", "Key");
        }
    }
}