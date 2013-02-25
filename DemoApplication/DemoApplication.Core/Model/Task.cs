namespace DemoApplication.Core.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Task : DomainObject
    {
        [Required]
        public string Name { get; set; }
    }
}
