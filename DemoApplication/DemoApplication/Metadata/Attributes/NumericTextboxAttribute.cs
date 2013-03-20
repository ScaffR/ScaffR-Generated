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
    public class NumericTextboxAttribute : TextboxAttribute
    {
        public NumericTextboxAttribute() : base("string")
        {
            this.DefaultTextboxSize = TextboxSize.Small;
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.NumericAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            double retNum;

            return double.TryParse(Convert.ToString(value), out retNum);
        }
    }
}
