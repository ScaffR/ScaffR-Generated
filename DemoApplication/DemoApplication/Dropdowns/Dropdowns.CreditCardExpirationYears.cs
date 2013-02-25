namespace DemoApplication.Dropdowns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public partial class Dropdowns
    {
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