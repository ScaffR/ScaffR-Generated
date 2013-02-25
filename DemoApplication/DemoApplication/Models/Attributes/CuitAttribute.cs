namespace DemoApplication.Models.Attributes
{
    using System;
    using System.Text.RegularExpressions;
    using Resources;

    [Obsolete("Migrate to using RegularExpressionAttribute instead, like [RegularExpression(Expressions.Cuit)]")]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CuitAttribute : TextboxAttribute
    {
        private static Regex _regex = new Regex(@"^[0-9]{2}-?[0-9]{8}-?[0-9]$");

        public string Regex
        {
            get
            {
                return _regex.ToString();
            }
        }

        public CuitAttribute()
            : base("cuit")
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.CuitAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var valueAsString = value as string;
            return valueAsString != null && _regex.Match(valueAsString).Length > 0;
        }
    }
}
