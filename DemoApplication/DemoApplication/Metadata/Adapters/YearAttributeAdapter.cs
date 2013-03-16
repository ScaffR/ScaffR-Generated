namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;

    public class YearAttributeAdapter : DataAnnotationsModelValidator<YearTextboxAttribute>
    {
        public YearAttributeAdapter(ModelMetadata metadata, ControllerContext context, YearTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRegexRule(ErrorMessage, Attribute.Regex) };
        }
    }
}