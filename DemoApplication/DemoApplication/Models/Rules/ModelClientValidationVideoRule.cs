using System.Web.Mvc;

namespace DemoApplication.Models.Rules
{
    public class ModelClientValidationVideoRule : ModelClientValidationRule
    {
        public ModelClientValidationVideoRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "Video";
        }
    }
}