#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-07-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Components
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

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