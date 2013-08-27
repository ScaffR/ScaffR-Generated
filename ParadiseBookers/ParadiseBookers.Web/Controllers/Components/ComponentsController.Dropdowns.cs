#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;
using ParadiseBookers.Models.Components;

namespace ParadiseBookers.Controllers.Components
{
    #region

    

    #endregion

    public partial  class ComponentsController
    {
        /// <summary>
        /// Demonstration of the DropDown framework.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult DropDown()
        {
            return View(new SampleDropdownModel());
        }
    }
}