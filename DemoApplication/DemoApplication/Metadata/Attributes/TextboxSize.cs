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

    using System.ComponentModel;

    #endregion

    /// <summary>
    /// Enum TextboxSize
    /// </summary>
    public enum TextboxSize
    {
        [Description("")]
        None,

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
        XXLarge,

        [Description("input-huge")]
        Huge
    }
}