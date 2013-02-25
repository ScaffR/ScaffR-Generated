namespace DemoApplication.Dropdowns
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Core.Common.Lists;

    public partial class Dropdowns
    {
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