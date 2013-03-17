namespace DemoApplication.Metadata.Rules
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ModelClientValidationNumericRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "number";
        }
    }
}