#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;

namespace ParadiseBookers.Metadata.Rules
{
    #region

    

    #endregion

    public class ModelClientValidationCKEditorRule : ModelClientValidationRule
    {
        public ModelClientValidationCKEditorRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "ckeditor";
        }
    }
}