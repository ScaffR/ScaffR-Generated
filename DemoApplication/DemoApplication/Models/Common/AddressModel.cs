namespace DemoApplication.Models.Common
{
    #region

    using System.Data.Spatial;
    using Metadata.Attributes;

    #endregion

    public class AddressModel
    {
        [HideSurroundingChrome, Textbox(TextboxSize = TextboxSize.XLarge)]
        public string Address { get; set; }

        [HideSurroundingChrome]
        public DbGeography Location { get; set; }
    }
}