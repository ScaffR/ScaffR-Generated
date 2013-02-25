namespace DemoApplication.Dropdowns
{
    using System.Web.Mvc;
    using Core.Common.Lists;

    public partial class Dropdowns
    {        
        public static SelectList Months()
        {
            return new SelectList(Lists.MonthDictionary, "Value", "Key");
        }
    }
}