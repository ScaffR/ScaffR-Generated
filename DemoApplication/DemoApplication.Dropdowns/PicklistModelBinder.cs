namespace DemoApplication.Dropdowns
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    #endregion

    public class PicklistModelBinder : DefaultModelBinder
    {
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor,
            IModelBinder propertyBinder)
        {
            var propertyType = propertyDescriptor.PropertyType;
            if ((typeof(IEnumerable<string>).IsAssignableFrom(propertyType)))
            {
                var providerValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (null != providerValue)
                {
                    var value = (IEnumerable<string>)providerValue.RawValue;
                    if (value.Contains("~"))
                    {
                        // this will remove all the extra properties
                        return new List<string> {"~"};
                    }
                }
            }

            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    }
}
