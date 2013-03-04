namespace DemoApplication.Models.Components
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    [Wizard]
    public class SampleWizardModel
    {
        public SampleWizardModel()
        {
            Step1 = new SampleWizardStep();
            Step2 = new SampleWizardStep();
            Step3 = new SampleWizardStep();
        }

        [WizardStep("Some Information")]
        public SampleWizardStep Step1 { get; set; }

        [WizardStep("More Information")]
        public SampleWizardStep Step2 { get; set; }

        [WizardStep("Even More Information")]
        public SampleWizardStep Step3 { get; set; }
    }

    public class SampleWizardStep
    {
        [Display(Name = "Sample Value")]
        public string SampleValue { get; set; }
    }
}