namespace DemoApplication.Extensions
{
    #region

    using Metadata.Attributes;

    #endregion

    public class BootstrapInputOptions
    {
        public string Type { get; set; }

        public TextboxSize Size { get; set; }

        public string Placeholder { get; set; }

        public bool Multiline { get; set; }

        public string Mask { get; set; }

        public FocusBehavior FocusBehavior { get; set; }
    }
}