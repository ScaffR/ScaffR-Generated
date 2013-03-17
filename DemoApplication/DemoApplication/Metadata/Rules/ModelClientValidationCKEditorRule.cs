namespace DemoApplication.Metadata.Rules
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ModelClientValidationCKEditorRule : ModelClientValidationRule
    {
        public ModelClientValidationCKEditorRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "ckeditor";
        }
    }
}