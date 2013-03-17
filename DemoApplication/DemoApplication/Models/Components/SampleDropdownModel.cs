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