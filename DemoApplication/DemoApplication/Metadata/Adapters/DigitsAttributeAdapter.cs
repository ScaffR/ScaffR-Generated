namespace DemoApplication.Metadata.Adapters
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    #endregion

    public class DigitsAttributeAdapter : DataAnnotationsModelValidator<DigitsTextboxAttribute>
    {
        public DigitsAttributeAdapter(ModelMetadata metadata, ControllerContext context, DigitsTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
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