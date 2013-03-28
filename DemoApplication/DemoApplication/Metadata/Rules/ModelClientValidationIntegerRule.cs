#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Rules
{
    #region

    using System.Web.Mvc;

    #endregion

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