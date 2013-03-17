namespace DemoApplication.Metadata.Rules
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ModelClientValidationDateRule : ModelClientValidationRule
    {
        public ModelClientValidationDateRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "date";
        }
    }
}