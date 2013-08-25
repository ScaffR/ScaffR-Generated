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
using System.Linq;
using System.Web.Mvc;
using ParadiseBookers.Core.Common.Lists;

namespace ParadiseBookers.Dropdowns.Dropdowns
{
    #region

    

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