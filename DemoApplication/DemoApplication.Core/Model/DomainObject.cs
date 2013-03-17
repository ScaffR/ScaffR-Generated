namespace DemoApplication.Core.Model
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #endregion

    public abstract class DomainObject : IValidatableObject
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }

		public byte[] RowVersion { get; set; }

        public DateTime? Updated { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Override this method to implement custom validation in your entities
            
            // This is only for making it compile... and returning null will give an exception.
            if (false)
                yield return new ValidationResult("Well, this should not happend...");
        }
    }
}