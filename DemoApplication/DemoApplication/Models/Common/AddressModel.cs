namespace DemoApplication.Models.Common
{
    using System.Data.Spatial;
    using Metadata.Attributes;

    public class AddressModel
    {
        [HideSurroundingChrome, Textbox(TextboxSize = TextboxSize.XLarge)]
        public string Address { get; set; }

        [HideSurroundingChrome]
        public DbGeography Location { get; set; }
    }
}