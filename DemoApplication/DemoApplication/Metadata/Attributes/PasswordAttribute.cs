namespace DemoApplication.Metadata.Attributes
{
    public class PasswordAttribute : TextboxAttribute
    {
        private TextboxSize _textboxSize = TextboxSize.XLarge;
        private string _placeholderText = string.Empty;

        public PasswordAttribute()
            : base("Password")
        {
        }
    }
}