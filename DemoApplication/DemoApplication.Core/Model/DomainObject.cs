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

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace DemoApplication.Core.Model
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #endregion

    public abstract class DomainObject : IValidatableObject
    {
        [NotMapped]
        [ScriptIgnore, XmlIgnore]
        public object Id
        {
            get
            {
                var keyAttributedProps = GetType().GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length == 1);
                return (keyAttributedProps != null) ? keyAttributedProps.GetValue(this, null) : "0";
            }
            set { }
        }

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