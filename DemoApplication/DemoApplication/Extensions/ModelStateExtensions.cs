namespace DemoApplication.Extensions
{
    #region

    using System.Web.Mvc;
    using Core.Interfaces.Validation;

    #endregion

    public static class ModelStateExtensions
    {
        public static bool Process(this ModelStateDictionary modelState, IValidationContainer result)
        {
            foreach (var r in result.ValidationErrors)
                foreach (var e in r.Value)
                    modelState.AddModelError(r.Key, e);
            return modelState.IsValid;
        }

        public static bool Process(this System.Web.Http.ModelBinding.ModelStateDictionary modelState,
            IValidationContainer result)
        {
            foreach (var r in result.ValidationErrors)
                foreach (var e in r.Value)
                    modelState.AddModelError(r.Key, e);
            return modelState.IsValid;
        }
    }
}