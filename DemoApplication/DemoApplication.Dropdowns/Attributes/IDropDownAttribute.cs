#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
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