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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using ParadiseBookers.Common.Extensions;

namespace ParadiseBookers.Dropdowns.Dropdowns
{
    #region

    

    #endregion

    public partial class Dropdowns
    {
        private static string GetDescription(object value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            var tempValue = attributes.Length > 0 ? attributes[0].Description : value.ToString();

            return tempValue;
        }

        public static IEnumerable<SelectListItem> ForEnum(Type enumType)
        {
            ICollection<SelectListItem> items = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            foreach (var value in Enum.GetValues(enumType))
            {


                items.Add(new SelectListItem
                              {
                                  Text = GetDescription(value),
                                  Value = ((int)value).ToString()
                              });
            }

            return items;
        }
    }
}