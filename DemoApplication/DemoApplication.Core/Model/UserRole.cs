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
    using Newtonsoft.Json;

    #endregion

    public partial class UserRole : DomainObject
    {
        [Required]
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
		[JsonIgnore]
        public virtual User User { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public int RoleId { get; set; }
        
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}