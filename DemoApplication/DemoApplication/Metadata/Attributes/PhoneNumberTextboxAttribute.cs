#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Attributes
{
    #region

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class PhoneNumberTextboxAttribute : TextboxAttribute
    {
        public PhoneNumberTextboxAttribute()
            : base(DataType.PhoneNumber)
        {
            this.DefaultTextboxSize = TextboxSize.Medium;
            this.Options.Mask = "(999) 999-9999? x99999";
        }
    }
}