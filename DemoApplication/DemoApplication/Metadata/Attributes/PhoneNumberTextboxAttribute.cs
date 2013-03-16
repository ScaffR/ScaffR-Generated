namespace DemoApplication.Metadata.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class PhoneNumberTextboxAttribute : TextboxAttribute
    {
        public PhoneNumberTextboxAttribute()
            : base(DataType.PhoneNumber)
        {
            this.DefaultTextboxSize = TextboxSize.Medium;
            this.Options.Mask = "(999) 999-9999";
        }
    }
}