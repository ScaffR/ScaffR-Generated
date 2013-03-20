#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Attributes
{
    #region

    using System;
    using Resources;

    #endregion

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DigitsTextboxAttribute : TextboxAttribute
    {
        public DigitsTextboxAttribute()
            : base("digits")
        {
            this.DefaultTextboxSize = TextboxSize.Small;
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.DigitsAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            long retNum;

            var parseSuccess = long.TryParse(Convert.ToString(value), out retNum);

            return parseSuccess && retNum >= 0;
        }
    }
}