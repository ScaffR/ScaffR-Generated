namespace DemoApplication.Metadata.Rules
{
    #region

    using System.Web.Mvc;

    #endregion

    public class ModelClientValidationVideoRule : ModelClientValidationRule
    {
        public ModelClientValidationVideoRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "Video";
        }
    }
}