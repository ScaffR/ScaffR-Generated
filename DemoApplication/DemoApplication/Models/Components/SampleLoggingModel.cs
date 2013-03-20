#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-07-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion

using System.ComponentModel.DataAnnotations;
using DemoApplication.Dropdowns.Attributes;
using DemoApplication.Metadata.Attributes;

namespace DemoApplication.Models.Components
{
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