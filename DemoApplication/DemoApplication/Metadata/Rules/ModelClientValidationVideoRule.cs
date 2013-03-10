namespace DemoApplication.Metadata.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationVideoRule : ModelClientValidationRule
    {
        public ModelClientValidationVideoRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "Video";
        }
    }
}