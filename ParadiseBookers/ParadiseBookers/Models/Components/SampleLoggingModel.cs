#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-20-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.ComponentModel.DataAnnotations;
using ParadiseBookers.Dropdowns.Attributes;
using ParadiseBookers.Metadata.Attributes;

namespace ParadiseBookers.Models.Components
{
    #region

    

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