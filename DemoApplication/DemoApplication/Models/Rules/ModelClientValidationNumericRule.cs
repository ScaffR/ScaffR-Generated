namespace DemoApplication.Models.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationNumericRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "number";
        }
    }
}