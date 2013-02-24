namespace DemoApplication.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class TextboxAttribute : DataTypeAttribute, IMetadataAware
    {
        private TextboxSize _textboxSize = TextboxSize.XLarge;
        private string _placeholderText = string.Empty;
        private string _mask;
        private FocusBehavior _focusBehavior = FocusBehavior.Normal;

        public TextboxAttribute()
            : this("String")
        {

        }

        public TextboxAttribute(DataType dataType) : base(dataType)
        {
            
        }

        public TextboxAttribute(string dataType)
            : base(dataType)
        {

        }

        public FocusBehavior FocusBehavior
        {
            get { return _focusBehavior; }
            set { _focusBehavior = value; }
        }

        public bool IsMultiline { get; set; }

        public TextboxSize TextboxSize
        {
            get { return _textboxSize; }
            set { _textboxSize = value; }
        }

        public string PlaceholderText
        {
            get { return _placeholderText; }
            set { _placeholderText = value; }
        }

        public string Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["textbox-size"] = _textboxSize;
            metadata.AdditionalValues["placeholder"] = _placeholderText;
            metadata.AdditionalValues["mask"] = _mask;
            metadata.AdditionalValues["focus-behavior"] = _focusBehavior;
            metadata.AdditionalValues["multiline"] = this.IsMultiline.ToString();
        }
    }

    public enum FocusBehavior
    {
        Normal,
        ClearOnFocus
    }
}