namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class CuitAttributeAdapter : DataAnnotationsModelValidator<CuitAttribute>
    {
        public CuitAttributeAdapter(ModelMetadata metadata, ControllerContext context, CuitAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationCuitRule(ErrorMessage, Attribute.Regex) };
        }
    }
}