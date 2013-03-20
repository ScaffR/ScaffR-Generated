#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
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
        /// Fors the enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of the T enum.</typeparam>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>SelectList.</returns>
        public static SelectList ForEnum<TEnum>(TEnum enumType)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = value.ToString(),
                                                    Value = value.ToString()
                                                };
            return new SelectList(items);
        }

        public static IEnumerable<SelectListItem> ForEnum(Type enumType)
        {
            ICollection<SelectListItem> items = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            foreach (var value in Enum.GetValues(enumType))
            {
                items.Add(new SelectListItem
                              {
                                  Text = value.ToString(),
                                  Value = ((int)value).ToString()
                              });
            }

            return items;
        }
    }
}