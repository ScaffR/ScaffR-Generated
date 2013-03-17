namespace DemoApplication.Metadata.Adapters
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    #endregion

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