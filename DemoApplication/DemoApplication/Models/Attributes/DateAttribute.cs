namespace DemoApplication.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Resources;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateAttribute : TextboxAttribute
    {
        public DateAttribute()
            : base(DataType.Date)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.DateAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            DateTime retDate;

            return DateTime.TryParse(Convert.ToString(value), out retDate);
        }
    }
}