namespace DemoApplication.Models.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationMaxRule : ModelClientValidationRule
    {
        public ModelClientValidationMaxRule(string errorMessage, object max)
        {
            ErrorMessage = errorMessage;
            ValidationType = "range";
            ValidationParameters["max"] = max;
        }
    }
}