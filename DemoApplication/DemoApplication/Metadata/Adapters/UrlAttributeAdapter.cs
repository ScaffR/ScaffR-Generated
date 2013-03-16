namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;

    public class UrlAttributeAdapter : DataAnnotationsModelValidator<UrlTextboxAttribute>
    {
        public UrlAttributeAdapter(ModelMetadata metadata, ControllerContext context, UrlTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRegexRule(ErrorMessage, Attribute.Regex) };
            //return new[] { new ModelClientValidationUrlRule(ErrorMessage) };
        }
    }
}
