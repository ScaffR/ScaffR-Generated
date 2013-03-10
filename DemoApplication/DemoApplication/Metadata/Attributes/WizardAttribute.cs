namespace DemoApplication.Metadata.Attributes
{
    using System;
    using System.Web.Mvc;

    public class WizardAttribute : Attribute, IMetadataAware
    {
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "Wizard";
        }
    }
}

