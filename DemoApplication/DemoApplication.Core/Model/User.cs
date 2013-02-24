namespace DemoApplication.Core.Model
{
    using System.ComponentModel.DataAnnotations;

    [DisplayColumn("Username")]
	public partial class User : Person
	{
		[Required]
		public virtual string Username { get; set; }

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
	}
}