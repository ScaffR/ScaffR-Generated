#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-20-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Components
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Dropdowns.Attributes;
    using Metadata.Attributes;

    #endregion

    #region

    

    #endregion

    public class SampleLoggingModel
    {
        [DropDown("EventStatus", OptionLabel = "- Select -")]
        public EventStatus Status { get; set; }

        [Textbox(TextboxSize = TextboxSize.XLarge)]
        [Display(Name = "Event")]
        public string Event { get; set; }

    }
}