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
using System.ComponentModel.DataAnnotations;
using ParadiseBookers.Metadata.Resources;

namespace ParadiseBookers.Metadata.Attributes
{
    #region

    

    #endregion

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateTextboxAttribute : TextboxAttribute
    {
        public DateTextboxAttribute()
            : base(DataType.DateTime)
        {
            this.DefaultTextboxSize = TextboxSize.Medium;
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