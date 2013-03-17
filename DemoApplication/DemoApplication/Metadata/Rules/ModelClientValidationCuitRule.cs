namespace DemoApplication.Metadata.Rules
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ModelClientValidationCuitRule : ModelClientValidationRule
    {
        public ModelClientValidationCuitRule(string errorMessage, string regex)
        {
            ErrorMessage = errorMessage;
            ValidationType = "regex";
            ValidationParameters["pattern"] = regex;
        }
    }
}