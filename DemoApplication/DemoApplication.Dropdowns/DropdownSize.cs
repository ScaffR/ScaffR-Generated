#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns
{
    #region

    using System.ComponentModel;

    #endregion

    public enum DropdownSize
    {
        [Description("input-mini")]
        Mini,

        [Description("input-small")]
        Small,

        [Description("input-medium")]
        Medium,

        [Description("input-large")]
        Large,

        [Description("input-xlarge")]
        XLarge,

        [Description("input-xxlarge")]
        XXLarge
    }
}