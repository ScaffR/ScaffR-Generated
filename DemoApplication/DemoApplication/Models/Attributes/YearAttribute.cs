namespace DemoApplication.Models.Attributes
{
    using System;
    using System.Text.RegularExpressions;
    using Resources;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class YearAttribute : TextboxAttribute
    {
        private static Regex _regex = new Regex(@"^[0-9]{4}$");

        public string Regex
        {
            get
            {
                return _regex.ToString();
            }
        }

        public YearAttribute()
            : base("year")
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.YearAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            int retNum;
            var parseSuccess = int.TryParse(Convert.ToString(value), out retNum);

            return parseSuccess && retNum >= 1 && retNum <= 9999;
        }
    }
}
