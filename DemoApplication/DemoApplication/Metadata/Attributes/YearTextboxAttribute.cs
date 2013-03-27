#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Attributes
{
    #region

    using System;
    using System.Text.RegularExpressions;
    using Resources;

    #endregion

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class YearTextboxAttribute : TextboxAttribute
    {
        private static Regex _regex = new Regex(@"^[0-9]{4}$");

        public string Regex
        {
            get
            {
                return _regex.ToString();
            }
        }

        public YearTextboxAttribute()
            : base("year")
        {
            this.DefaultTextboxSize = TextboxSize.Small;
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
