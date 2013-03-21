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
namespace DemoApplication.ModelBinders
{
    #region

    using System;
    using System.Data.Spatial;
    using System.Web.ModelBinding;
    using System.Web.Mvc;

    #endregion

    public class DbGeographyModelBinder : System.Web.Mvc.IModelBinder, System.Web.ModelBinding.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            return BindModelImpl(valueProviderResult != null ? valueProviderResult.AttemptedValue : null);
        }

        public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, System.Web.ModelBinding.ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            bindingContext.Model = BindModelImpl(valueProviderResult != null ? valueProviderResult.AttemptedValue : null);
            return bindingContext.Model != null;
        }

        private DbGeography BindModelImpl(string value)
        {
            if (value == null)
            {
                return (DbGeography)null;
            }
            string[] latLongStr = value.Split(',');
            // TODO: More error handling here, what if there is more than 2 pieces or less than 2?
            //       Are we supposed to populate ModelState with errors here if we can't conver the value to a point?
            string point = string.Format("POINT ({0} {1})", latLongStr[1], latLongStr[0]);
            //4326 format puts LONGITUDE first then LATITUDE
            DbGeography result = DbGeography.FromText(point, 4326);
            return result;
        }
    }



    public class EFModelBinderProviderMvc : System.Web.Mvc.IModelBinderProvider
    {
        public System.Web.Mvc.IModelBinder GetBinder(Type modelType)
        {
            if (modelType == typeof(DbGeography))
                return new DbGeographyModelBinder();
            return null;
        }
    }

    public class EFModelBinderProviderWebForms : System.Web.ModelBinding.ModelBinderProvider
    {
        public override System.Web.ModelBinding.IModelBinder GetBinder(ModelBindingExecutionContext modelBindingExecutionContext, System.Web.ModelBinding.ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(DbGeography))
                return new DbGeographyModelBinder();
            return null;
        }
    }
}