#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Collections.Generic;
using System.Web.Mvc;

namespace ParadiseBookers.Dropdowns.Attributes
{
    #region

    

    #endregion

    public interface IDropDownAttribute
    {
        string DependsOn { get; set; }
        IEnumerable<SelectListItem> GetMethodResult();
    }
}