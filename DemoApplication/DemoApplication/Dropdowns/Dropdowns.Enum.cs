namespace DemoApplication.Dropdowns
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ScaffR.Extensions;

    #endregion

    public partial class Dropdowns
    {
        public static SelectList ForEnum<TEnum>(TEnum enumType)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = EnumExtensions.GetEnumDescription(value),
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