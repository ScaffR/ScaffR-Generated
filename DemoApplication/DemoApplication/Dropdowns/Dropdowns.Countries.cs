namespace DemoApplication.Dropdowns
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Core.Common.Lists;

    public partial class Dropdowns : IDropdownProvider
    {        
        public static IEnumerable<SelectListItem> Countries()
        {
            return new SelectList(Lists.CountryDictionary, "Value", "Key");
        }
    }
}