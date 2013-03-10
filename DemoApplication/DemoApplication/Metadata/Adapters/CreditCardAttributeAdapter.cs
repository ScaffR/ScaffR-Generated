namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class CreditCardAttributeAdapter : DataAnnotationsModelValidator<CreditCardAttribute>
    {
        public CreditCardAttributeAdapter(ModelMetadata metadata, ControllerContext context, CreditCardAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationCreditCardRule(ErrorMessage) };
        }
    }
}