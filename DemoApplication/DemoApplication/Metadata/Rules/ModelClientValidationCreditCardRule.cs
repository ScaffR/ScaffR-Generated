namespace DemoApplication.Metadata.Rules
{
    using System.Web.Mvc;

    public class ModelClientValidationCreditCardRule : ModelClientValidationRule
    {
        public ModelClientValidationCreditCardRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "creditcard";
        }
    }
}