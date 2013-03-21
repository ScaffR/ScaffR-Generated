#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Adapters
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using Resources;

    #endregion

    public class EqualToAttributeAdapter : DataAnnotationsModelValidator<EqualToAttribute>
    {
        public EqualToAttributeAdapter(ModelMetadata metadata, ControllerContext context, EqualToAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            Attribute.OtherPropertyDisplayName = GetOtherPropertyDisplayName();

            var otherProp = FormatPropertyForClientValidation(Attribute.OtherProperty);
            //We'll just use the built-in System.Web.Mvc client validation rule
            return new[] { new ModelClientValidationEqualToRule(ErrorMessage, otherProp) };
        }

        private string GetOtherPropertyDisplayName()
        {
            if (Metadata.ContainerType != null && !String.IsNullOrEmpty(Attribute.OtherProperty))
            {
                var propertyMetaData = ModelMetadataProviders.Current.GetMetadataForProperty(() => Metadata.Model,
                                                                                             Metadata.ContainerType,
                                                                                             Attribute.OtherProperty);

                return propertyMetaData.GetDisplayName();
            }

            return Attribute.OtherProperty;
        }

        public static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException(ClientValidationResources.Common_NullOrEmpty, "property");
            }
            return "*." + property;
        }
    }
}