namespace DemoApplication.Metadata.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationFileExtensionsRule : ModelClientValidationRule
    {
        public ModelClientValidationFileExtensionsRule(string errorMessage, string extensions)
        {
            ErrorMessage = errorMessage;
            ValidationType = "accept";
            ValidationParameters["exts"] = extensions;
        }
    }
}