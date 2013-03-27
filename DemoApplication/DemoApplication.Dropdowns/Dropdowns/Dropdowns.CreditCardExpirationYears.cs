#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns.Dropdowns
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    #endregion

    public partial class Dropdowns
    {
        /// <summary>
        /// Gets a IEnumerable{SelectListItem} with the next 5 years.
        /// </summary>
        /// <returns>IEnumerable{SelectListItem}.</returns>
        public IEnumerable<SelectListItem> CreditCardExpirationYears()
        {
            var years = new List<int>();
            var currentYear = DateTime.Now.Year;
            while (currentYear < DateTime.Now.Year + 5)
            {
                years.Add(currentYear++);
            }

            return years.Select(m => new SelectListItem
            {
                Text = m.ToString(),
                Value = m.ToString()
            });
        }
    }
}