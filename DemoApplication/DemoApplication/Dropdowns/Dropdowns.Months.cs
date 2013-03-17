namespace DemoApplication.Dropdowns
{
    #region

    using System.Web.Mvc;
    using Core.Common.Lists;

    #endregion

    public partial class Dropdowns
    {        
        public static SelectList Months()
        {
            return new SelectList(Lists.MonthDictionary, "Value", "Key");
        }
    }
}