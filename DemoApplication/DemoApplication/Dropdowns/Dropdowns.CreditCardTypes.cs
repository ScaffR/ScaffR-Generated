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
    using System.Linq;
    using System.Web.Mvc;
    using Core.Common.Lists;

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