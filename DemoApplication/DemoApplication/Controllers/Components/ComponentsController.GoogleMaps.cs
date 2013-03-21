#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-06-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;
    using Core.Common.Geography;
    using Extensions.TempDataHelpers;
    using Models.Common;

    #endregion

    public partial class ComponentsController
    {
        /// <summary>
        /// Demonstration of Google Maps
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult GoogleMaps()
        {
            var model = new AddressModel
            {
                Address = "301 15th Street, Hood River",
                Location = GeographyHelpers.CreatePoint(45.7120903, -121.5272902)
            };

            return View(model);
        }

        /// <summary>
        /// Demonstration of Google Maps
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, AllowAnonymous]
        public ActionResult GoogleMaps(AddressModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.AddSuccessMessage("Location was successfully submitted");
            }
            return View(model);
        }

    }
}
