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

using System;
using System.Web.Mvc;

namespace ParadiseBookers.Metadata.Attributes
{
    #region

    

    #endregion

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