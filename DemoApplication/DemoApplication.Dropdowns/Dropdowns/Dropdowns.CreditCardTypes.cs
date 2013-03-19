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
namespace DemoApplication.Dropdowns.Dropdowns
{
    #region

    using System.Linq;
    using DemoApplication.Core.Common.Lists;
    using System.Collections.Generic;
    using System.Web.Mvc;

    #endregion

    public partial class Dropdowns
    {
        /// <summary>
        /// Credits the card types.
        /// </summary>
        /// <returns>IEnumerable{SelectListItem}.</returns>
        public IEnumerable<SelectListItem> CreditCardTypes()
        {
            return Lists.CreditCardDictionary.Select(m => new SelectListItem
            {
                Text = m.Key,
                Value = m.Value
            });
        }
    }
}