namespace DemoApplication.Metadata.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationMinRule : ModelClientValidationRule
    {
        public ModelClientValidationMinRule(string errorMessage, object min)
        {
            ErrorMessage = errorMessage;
            ValidationType = "range";
            ValidationParameters["min"] = min;
        }
    }
}