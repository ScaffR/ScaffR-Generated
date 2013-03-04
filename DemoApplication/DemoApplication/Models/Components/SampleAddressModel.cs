namespace DemoApplication.Models.Components
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Spatial;

    public class SampleAddressModel
    {
        [Display(Name = "Address")]
        public DbGeography Address { get; set; }
    }
}