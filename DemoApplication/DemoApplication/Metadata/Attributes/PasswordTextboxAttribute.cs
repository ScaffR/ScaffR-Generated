#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Attributes
{
    public class PasswordTextboxAttribute : TextboxAttribute
    {
        public PasswordTextboxAttribute()
            : base("Password")
        {
        }
    }
}