namespace DemoApplication.Models.Account
{
    #region

    using System;
    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    public partial class ProfileModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [EmailTextbox]
        [Display(Name = "Email Address")]
        public virtual String Email { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [PhoneNumberTextbox]
        public string PhoneNumber { get; set; }
    }
}