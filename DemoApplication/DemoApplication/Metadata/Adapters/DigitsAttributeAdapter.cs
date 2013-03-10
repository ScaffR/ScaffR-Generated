namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class DigitsAttributeAdapter : DataAnnotationsModelValidator<DigitsAttribute>
    {
        public DigitsAttributeAdapter(ModelMetadata metadata, ControllerContext context, DigitsAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationDigitsRule(ErrorMessage) };
        }
    }

    public class IntegerAttributeAdapter : DataAnnotationsModelValidator<IntegerAttribute>
    {
        public IntegerAttributeAdapter(ModelMetadata metadata, ControllerContext context, IntegerAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationIntegerRule(ErrorMessage) };
        }
    }
}