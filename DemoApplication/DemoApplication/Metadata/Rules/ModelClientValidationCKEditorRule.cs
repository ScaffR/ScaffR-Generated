namespace DemoApplication.Metadata.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationCKEditorRule : ModelClientValidationRule
    {
        public ModelClientValidationCKEditorRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "ckeditor";
        }
    }
}