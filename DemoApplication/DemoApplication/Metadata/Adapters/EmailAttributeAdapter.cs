namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class EmailAttributeAdapter : DataAnnotationsModelValidator<EmailTextboxAttribute>
    {
        public EmailAttributeAdapter(ModelMetadata metadata, ControllerContext context, EmailTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationEmailRule(ErrorMessage) };
        }
    }
}