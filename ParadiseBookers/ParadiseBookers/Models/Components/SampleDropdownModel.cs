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

using System.ComponentModel.DataAnnotations;
using ParadiseBookers.Dropdowns.Attributes;

namespace ParadiseBookers.Models.Components
{
    #region

    

    #endregion

    public class SampleDropdownModel
    {
        [DropDown("Countries", OptionLabel = "-Select an option-")]
        [Display(Name = "Country")]
        public string CountryId { get; set; }

        [CascadingDropDown("CountryId", "States", OptionLabel = "-Select an option-")]
        [Display(Name = "State")]
        public string StateId { get; set; }
    }
}