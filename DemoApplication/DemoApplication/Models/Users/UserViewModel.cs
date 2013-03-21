#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Users
{
    #region

    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    [DisplayColumn("Username")]
    public partial class UserViewModel
    {
        [Display(Name = "First Name")]
        [Textbox, Required]
        public virtual string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Textbox, Required]
        public virtual string LastName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Full Name", Order = 1)]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [Display(Name = "Username", Order = 2)]
        [ReadOnly(true)]
        [Textbox]
        public virtual string Username { get; set; }

        [Photo("Medium")]
        [Display(Name = "Photo")]
        [ScaffoldColumn(false)]
        public string PhotoId { get; set; }

        [Display(Name = "Last Activity Date")]
        [ScaffoldColumn(false)]
        public virtual DateTime? LastActivityDate { get; set; }

        [Display(Name = "Last Login Date")]
        [ScaffoldColumn(false)]
        public virtual DateTime? LastLoginDate { get; set; }

        [Required]
        [EmailTextbox]
        [Display(Name = "Email Address")]
        public virtual string Email { get; set; }

        [CKEditor(ToolBar = CKEditorToolbar.Full)]
        public virtual string Comment { get; set; }

        [Display(Name = "Approved")]
        public virtual bool IsApproved { get; set; }

        [Display(Name = "Locked Out")]
        public virtual bool IsLockedOut { get; set; }
    }
}