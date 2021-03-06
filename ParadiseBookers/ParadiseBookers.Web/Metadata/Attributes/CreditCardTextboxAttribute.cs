#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Linq;
using ParadiseBookers.Metadata.Resources;

namespace ParadiseBookers.Metadata.Attributes
{
    #region

    

    #endregion

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CreditCardTextboxAttribute : TextboxAttribute
    {
        public CreditCardTextboxAttribute()
            : base("String")
        {
            this.DefaultTextboxSize = TextboxSize.Large; 
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.CreditCardAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var ccValue = value as string;
            if (ccValue == null)
            {
                return false;
            }

            ccValue = ccValue.Replace("-", string.Empty).Replace(" ", string.Empty);

            if (string.IsNullOrEmpty(ccValue)) return false; //Don't accept only dashes/spaces

            int checksum = 0;
            bool evenDigit = false;

            // http://www.beachnet.com/~hstiles/cardtype.html
            foreach (char digit in ccValue.Reverse())
            {
                if (!Char.IsDigit(digit))
                {
                    return false;
                }

                int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return (checksum % 10) == 0;
        }
    }
}