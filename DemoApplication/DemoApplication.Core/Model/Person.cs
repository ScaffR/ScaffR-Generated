namespace DemoApplication.Core.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Person : DomainObject
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