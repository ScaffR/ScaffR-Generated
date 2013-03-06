using DemoApplication.Models.Attributes;

namespace DemoApplication.Models.Components
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Spatial;

    public class SampleAddressModel
    {
        [HideSurroundingChrome, Textbox(TextboxSize = TextboxSize.XLarge)]
        public string Address { get; set; }

        [HideSurroundingChrome]
        public DbGeography Location { get; set; }
    }
}