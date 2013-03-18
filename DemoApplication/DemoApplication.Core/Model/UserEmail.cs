#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Model
{
    #region

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    public class UserEmail : DomainObject
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }

        [Key, Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]        
        public virtual User User { get; set; }
    }
}
