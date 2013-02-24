namespace DemoApplication.Models.Attributes
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface IDropDownAttribute
    {
        IEnumerable<SelectListItem> GetMethodResult();
    }
}