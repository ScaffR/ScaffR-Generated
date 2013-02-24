namespace DemoApplication.Models.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationEmailRule : ModelClientValidationRule
    {
        public ModelClientValidationEmailRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "email";
        }
    }
}