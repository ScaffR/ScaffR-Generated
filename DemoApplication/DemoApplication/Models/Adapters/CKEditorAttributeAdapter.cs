using DemoApplication.Models.Attributes;
using DemoApplication.Models.Rules;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DemoApplication.Models.Adapters
{
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