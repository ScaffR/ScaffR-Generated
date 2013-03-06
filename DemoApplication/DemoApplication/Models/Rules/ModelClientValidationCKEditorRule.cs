using System.Web.Mvc;

namespace DemoApplication.Models.Rules
{
    public class ModelClientValidationCKEditorRule : ModelClientValidationRule
    {
        public ModelClientValidationCKEditorRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "ckeditor";
        }
    }
}