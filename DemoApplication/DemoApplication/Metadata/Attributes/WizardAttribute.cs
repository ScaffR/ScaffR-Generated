#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Attributes
{
    #region

    using System;
    using System.Web.Mvc;

    #endregion

    public class WizardAttribute : Attribute, IMetadataAware
    {
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "Wizard";
        }
    }
}

