namespace DemoApplication.Core.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserEmail : DomainObject
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]        
        public virtual User User { get; set; }
    }
}
