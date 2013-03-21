#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Model
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #endregion

    [DisplayColumn("Username")]
    public partial class User : DomainObject
    {

        [Key, Required]
        public virtual int UserId { get; set; }

        [Required]
        public virtual string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }

        public Gender Gender { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [Required, DataType(DataType.Password)]
        public virtual string Password { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string Comment { get; set; }

        public bool ResetPassword { get; set; }

        public bool ShowWelcomePage { get; set; }

        public string TemporaryPassword { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<UserClaim> Claims { get; set; }


        public User()
        {
            Claims = new List<UserClaim>();
        }
    }
}