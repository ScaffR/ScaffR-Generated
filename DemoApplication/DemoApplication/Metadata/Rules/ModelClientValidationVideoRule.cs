#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
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