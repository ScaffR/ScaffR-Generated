namespace DemoApplication.Extensions
{
    using System.Web.Mvc;
    using Core.Interfaces.Validation;

    public static class ModelStateExtensions
    {
        public static bool Process(this ModelStateDictionary modelState, IValidationContainer result)
        {
            foreach (var r in result.ValidationErrors)
            {
                foreach (var e in r.Value)
                {
                    modelState.AddModelError(r.Key, e);
                }
            }
            return modelState.IsValid;
        }
    }
}