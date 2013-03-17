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

