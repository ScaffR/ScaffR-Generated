namespace DemoApplication.Models.Components
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    public partial class CKEditorModel
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