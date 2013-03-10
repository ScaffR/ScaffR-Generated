namespace DemoApplication.Metadata.Attributes
{
    using System;
    using System.Web.Mvc;

    public class WizardStepAttribute : Attribute, IMetadataAware
    {
        public WizardStepAttribute(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public string TemplateHint { get; set; }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (!string.IsNullOrWhiteSpace(this.TemplateHint))
            {
                metadata.TemplateHint = this.TemplateHint;
            }
            metadata.AdditionalValues.Add("WizardStep", true);
            metadata.DisplayName = Title;
        }
    }

    public static class WizardExtensions
    {
        public static bool IsPropertyWizardStep(this ModelMetadata metadata)
        {
            return metadata.AdditionalValues.ContainsKey("WizardStep");
        }
    }
}