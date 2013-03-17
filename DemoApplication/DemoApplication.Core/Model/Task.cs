namespace DemoApplication.Core.Model
{
    #region

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class Task : DomainObject
    {
        [Required]
        public string Name { get; set; }
    }
}
