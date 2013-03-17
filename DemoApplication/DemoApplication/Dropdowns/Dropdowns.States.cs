namespace DemoApplication.Dropdowns
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Core.Common.Lists;

    #endregion

    public partial class Dropdowns
    {
        public static IEnumerable<SelectListItem> States(string code)
        {
            if (code == "US")
            {
                return new SelectList(Lists.UnitedStates, "Value", "Key");
            }
            if (code == "CA")
            {
                return new SelectList(Lists.CanadianProvinces, "Value", "Key");
            }
            return new List<SelectListItem>();
        }
    }
}