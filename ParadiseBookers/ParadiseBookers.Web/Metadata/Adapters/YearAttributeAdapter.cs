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

using System.Collections.Generic;
using System.Web.Mvc;
using ParadiseBookers.Metadata.Attributes;

namespace ParadiseBookers.Metadata.Adapters
{
    #region

    

    #endregion

    public class YearAttributeAdapter : DataAnnotationsModelValidator<YearTextboxAttribute>
    {
        public YearAttributeAdapter(ModelMetadata metadata, ControllerContext context, YearTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRegexRule(ErrorMessage, Attribute.Regex) };
        }
    }
}