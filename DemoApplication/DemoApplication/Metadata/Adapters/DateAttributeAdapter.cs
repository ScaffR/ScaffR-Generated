namespace DemoApplication.Metadata.Adapters
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    #endregion

    public class DateAttributeAdapter : DataAnnotationsModelValidator<DateTextboxAttribute>
    {
        public DateAttributeAdapter(ModelMetadata metadata, ControllerContext context, DateTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationDateRule(ErrorMessage) };
        }
    }
}