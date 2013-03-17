namespace DemoApplication.Dropdowns.Attributes
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;

    #endregion

    public interface IDropDownAttribute
    {
        string DependsOn { get; set; }
        IEnumerable<SelectListItem> GetMethodResult();
    }
}