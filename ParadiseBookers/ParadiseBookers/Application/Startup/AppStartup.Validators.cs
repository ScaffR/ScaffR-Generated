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
#region

using System.Web.Mvc;
using ParadiseBookers.Application.Startup;
using ParadiseBookers.Metadata.Adapters;
using ParadiseBookers.Metadata.Attributes;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "RegisterValidationExtensions")]
namespace ParadiseBookers.Application.Startup
{
    #region

    

    #endregion

    public partial class AppStartup
    {
        public static void RegisterValidationExtensions()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(EmailTextboxAttribute), typeof(EmailAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(UrlTextboxAttribute), typeof(UrlAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CreditCardTextboxAttribute), typeof(CreditCardAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(EqualToAttribute), typeof(EqualToAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(FileExtensionsAttribute), typeof(FileExtensionsAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(NumericTextboxAttribute), typeof(NumericAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(DigitsTextboxAttribute), typeof(DigitsAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MinAttribute), typeof(MinAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MaxAttribute), typeof(MaxAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(DateTextboxAttribute), typeof(DateAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(IntegerAttribute), typeof(IntegerAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(YearTextboxAttribute), typeof(YearAttributeAdapter));
        }
    }
}