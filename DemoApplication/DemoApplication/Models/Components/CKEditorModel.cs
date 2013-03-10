using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Models.Components
{
    using Metadata.Attributes;

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