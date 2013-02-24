namespace DemoApplication.Models.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationIntegerRule : ModelClientValidationRule
    {
        private const string Regex = @"^-?\d+$";

        public ModelClientValidationIntegerRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "regex";
            ValidationParameters["pattern"] = Regex;
        }
    }
}