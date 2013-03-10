namespace DemoApplication.Metadata.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationDateRule : ModelClientValidationRule
    {
        public ModelClientValidationDateRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "date";
        }
    }
}