#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Components
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Dropdowns.Attributes;

    #endregion

    public class SampleDropdownModel
    {
        [DropDown("Countries")]
        [Display(Name = "Country")]
        public string CountryId { get; set; }

        [CascadingDropDown("CountryId", "States")]
        [Display(Name = "State")]
        public string StateId { get; set; }
    }
}