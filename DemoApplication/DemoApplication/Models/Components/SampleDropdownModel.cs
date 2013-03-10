namespace DemoApplication.Models.Components
{
    using System.ComponentModel.DataAnnotations;
    using Dropdowns.Attributes;

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