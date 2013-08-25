#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-07-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.ComponentModel.DataAnnotations;
using ParadiseBookers.Metadata.Attributes;

namespace ParadiseBookers.Models.Components
{
    #region

    

    #endregion

    public partial class SampleEditorModel
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [Display(Name = "Name")]
        [Textbox, Required]
        public virtual string Name { get; set; }

        [CKEditor(ToolBar = CKEditorToolbar.Full)]
        public virtual string Description { get; set; }

    }
}