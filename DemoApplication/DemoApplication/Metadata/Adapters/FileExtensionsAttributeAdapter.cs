namespace DemoApplication.Metadata.Adapters
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    public class FileExtensionsAttributeAdapter : DataAnnotationsModelValidator<FileExtensionsAttribute>
    {
        public FileExtensionsAttributeAdapter(ModelMetadata metadata, ControllerContext context, FileExtensionsAttribute attribute)
            : base(metadata, context, attribute)
        {
            
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationFileExtensionsRule(ErrorMessage, Attribute.Extensions) };
        }
    }
}