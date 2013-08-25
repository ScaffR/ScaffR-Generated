#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Metadata.Attributes;

namespace ParadiseBookers.Models.Users
{
    #region

    

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

        [Display(Name = "Is Account Verified?")]
        public virtual bool IsAccountVerified { get; set; }

        [Display(Name = "Can User Login?")]
        public virtual bool IsLoginAllowed { get; set; }

        [Display(Name = "Is Account Closed?")]
        public virtual bool IsAccountClosed { get; set; }
    }

    public class UserHistory : UserViewModel
    {
        public UserHistory()
        {
            Logs = new List<Log>();
        }

        public IList<Log> Logs { get; set; }
    }
}