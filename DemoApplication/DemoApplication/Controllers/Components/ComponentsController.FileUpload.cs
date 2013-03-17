#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-07-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// Class ComponentsController
    /// </summary>
    public partial class ComponentsController
    {
        /// <summary>
        /// Demonstration of the file upload.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FileUpload()
        {
            return View();
        }

    }
}
