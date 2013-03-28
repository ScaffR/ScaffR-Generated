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
namespace DemoApplication.Metadata.Adapters
{
    #region

    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Rules;

    #endregion

    public class EmailAttributeAdapter : DataAnnotationsModelValidator<EmailTextboxAttribute>
    {
        public EmailAttributeAdapter(ModelMetadata metadata, ControllerContext context, EmailTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationEmailRule(ErrorMessage) };
        }
    }
}