#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Model
{
    #region

    using System.ComponentModel.DataAnnotations;

    #endregion

    public partial class User 
    {

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
    }
}