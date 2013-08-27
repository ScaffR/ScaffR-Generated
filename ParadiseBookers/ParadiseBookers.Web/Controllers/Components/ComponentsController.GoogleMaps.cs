#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-06-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;
using ParadiseBookers.Core.Common.Geography;
using ParadiseBookers.Extensions.TempDataHelpers;
using ParadiseBookers.Models.Common;

namespace ParadiseBookers.Controllers.Components
{
    #region

    

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
