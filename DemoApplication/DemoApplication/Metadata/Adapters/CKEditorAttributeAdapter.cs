namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class CKEditorAttributeAdapter : DataAnnotationsModelValidator<CKEditorAttribute>
    {
        public CKEditorAttributeAdapter(ModelMetadata metadata, ControllerContext context, CKEditorAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationCKEditorRule(ErrorMessage) };
        }
    }
}