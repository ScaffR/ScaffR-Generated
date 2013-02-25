namespace DemoApplication.Models.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class MinAttributeAdapter : DataAnnotationsModelValidator<MinAttribute>
    {
        public MinAttributeAdapter(ModelMetadata metadata, ControllerContext context, MinAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationMinRule(ErrorMessage, Attribute.Min) };
        }
    }
}