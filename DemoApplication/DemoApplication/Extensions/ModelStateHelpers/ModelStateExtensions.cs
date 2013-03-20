#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Extensions.ModelStateHelpers
{
    #region

    using System.Web.Mvc;
    using Core.Interfaces.Validation;

    #endregion

    public static class ModelStateExtensions
    {
        /// <summary>
        /// Processes the specified model state.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public static bool Process(this ModelStateDictionary modelState, IValidationContainer result)
        {
            foreach (var r in result.ValidationErrors)
                foreach (var e in r.Value)
                    modelState.AddModelError(r.Key, e);
            return modelState.IsValid;
        }

        /// <summary>
        /// Processes the specified model state.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
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