#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-04-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Components
{
    #region

    using System.ComponentModel.DataAnnotations;
    using Metadata.Attributes;

    #endregion

    [Wizard]
    public class SampleWizardModel
    {
        public SampleWizardModel()
        {
            Step1 = new UserModel();
            Step2 = new TelevisionPreferencesModel();
            Step3 = new FoodPreferencesModel();
        }

        [WizardStep("User Information")]
        public UserModel Step1 { get; set; }

        [WizardStep("Television Preferences")]
        public TelevisionPreferencesModel Step2 { get; set; }

        [WizardStep("Food Preferences")]
        public FoodPreferencesModel Step3 { get; set; }
    }

    public class UserModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName{ get; set; }
    }

    public class TelevisionPreferencesModel
    {
        [Display(Name = "Favorite TVShow")]
        public string FavoriteTvShow { get; set; }

        [Display(Name = "Owns TV?")]
        public bool HasTv { get; set; }
    }

    public class FoodPreferencesModel
    {
        [Display(Name = "Allergies")]
        public string Allergies { get; set; }
    }
}