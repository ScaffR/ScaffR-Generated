namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class DateAttributeAdapter : DataAnnotationsModelValidator<DateAttribute>
    {
        public DateAttributeAdapter(ModelMetadata metadata, ControllerContext context, DateAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationDateRule(ErrorMessage) };
        }
    }
}