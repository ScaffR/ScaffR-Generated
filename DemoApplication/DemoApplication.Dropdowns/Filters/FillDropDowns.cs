#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns.Filters
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Spatial;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Attributes;

    #endregion

    public class FillDropDowns : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;
            var viewData = filterContext.Controller.ViewData;

            if (viewModel != null)
            {
                var properties = GetPropertyInfo(viewModel.GetType(), viewData, 0);

                foreach (var prop in properties)
                {
                    var dropdownAttr = prop.GetCustomAttribute<DropDownAttribute>();
                    if (dropdownAttr != null)
                    {
                        var cascadingAttr = dropdownAttr as CascadingDropDownAttribute;
                        var enumAttr = dropdownAttr as EnumDropDownAttribute;
                        var explicitAttr = dropdownAttr as ExplicitDropdownAttribute;
                        if (cascadingAttr != null && !string.IsNullOrEmpty(cascadingAttr.ParentName))
                        {
                            var data = ModelMetadata.FromStringExpression(cascadingAttr.ParentName, viewData);

                            if (data == null || string.IsNullOrEmpty(data.PropertyName)  )
                                throw new Exception(string.Format("Unable to find property '{0}'",
                                    cascadingAttr.ParentName));

                            if (cascadingAttr.RequireHeirarchy)
                                SetViewdataWithValues(cascadingAttr, prop.Name, viewData,
                                    GetParentValues(cascadingAttr, viewData).ToArray());
                            else
                                SetViewdataWithValue(cascadingAttr, prop.Name, viewData, data.Model);

                        }
                        else if (enumAttr != null)
                        {
                            SetViewdata(enumAttr, prop.Name, viewData);
                        }
                        else if (explicitAttr != null)
                        {
                            var attrs = prop.GetCustomAttributes<DropdownOptionAttribute>();
                            SetExplicitViewdata(prop.Name, viewData, attrs);
                        }
                        else
                            SetViewdata(dropdownAttr, prop.Name, viewData);
                    }
                }
            }

            base.OnResultExecuting(filterContext);
        }

        private IEnumerable<object> GetParentValues(CascadingDropDownAttribute child, ViewDataDictionary viewData)
        {
            var parentMetadata = ModelMetadata.FromStringExpression(child.ParentName, viewData);

            var viewModelType = parentMetadata.ContainerType;
            var parentProperty = parentMetadata.PropertyName;

            var properties = GetPropertyInfo(viewModelType, viewData, 0);

            var theProperty = properties.FirstOrDefault(x => x.Name == parentProperty);

            var cascadingAttr = theProperty.GetCustomAttribute<CascadingDropDownAttribute>();
            if (cascadingAttr != null)
            {
                foreach (var obj in GetParentValues(cascadingAttr, viewData))
                {
                    yield return obj;
                }
            }
            yield return parentMetadata.Model;
        }

        private static void SetExplicitViewdata(string name, IDictionary<string, object> viewData, IEnumerable<DropdownOptionAttribute> attributes)
        {
            IEnumerable<SelectListItem> items = attributes.OrderBy(x => x.Order).Select(x => new SelectListItem()
                {
                    Text = x.Text,
                    Value = x.Value
                });

            var viewDataKey = "DDKey_" + name;
            viewData[viewDataKey] = viewData[viewDataKey] ?? items;
        }


        private static void SetViewdataWithValues(CascadingDropDownAttribute attr, string name, IDictionary<string, object> viewData, params object[] values)
        {
            var viewDataKey = "DDKey_" + name;
            viewData[viewDataKey] = viewData[viewDataKey] ?? attr.GetMethodResult(values);
        }

        private static void SetViewdataWithValue(DropDownAttribute attr, string name, IDictionary<string, object> viewData, object value)
        {
            var viewDataKey = "DDKey_" + name;
            viewData[viewDataKey] = viewData[viewDataKey] ?? attr.GetMethodResult(value);
        }

        private static void SetViewdata(IDropDownAttribute attr, string name, ViewDataDictionary viewData)
        {
            if (!string.IsNullOrWhiteSpace(attr.DependsOn))
            {
                var metaData = ModelMetadata.FromStringExpression(attr.DependsOn, viewData);
                SetViewdataWithValue((DropDownAttribute)attr, name, viewData, metaData.Model);
            }
            else
            {
                var viewDataKey = "DDKey_" + name;
                viewData[viewDataKey] = viewData[viewDataKey] ?? attr.GetMethodResult();
            }
        }

        private static bool attributeMatch(Attribute attr)
        {
            return attr is IDropDownAttribute;
        }

        private static bool propertyMatch(PropertyInfo prop)
        {
            return prop.GetCustomAttributes().Where(attributeMatch).Any();
        }

        private static bool propertyFilter(PropertyInfo prop)
        {
            return (!(prop.PropertyType.IsClass && !(prop.PropertyType == typeof(string)) && !(prop.PropertyType == typeof(DbGeography))));
        }

        private static IEnumerable<PropertyInfo> GetPropertyInfo(Type viewModelType, IDictionary<string, object> viewData, int count)
        {
            if (count < 4) // dont recurse too much
            {
                foreach (var property in viewModelType.GetProperties().Where(propertyFilter))
                {
                    if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                    {
                        foreach (var prop in GetPropertyInfo(property.PropertyType, viewData, count + 1))
                        {
                            yield return prop;
                        }
                    }
                    else
                    {
                        if (propertyMatch(property))
                        {
                            yield return property;
                        }
                    }
                }

                foreach (var property in viewModelType.GetProperties().Where(prop => prop.PropertyType.IsClass && !(prop.PropertyType == typeof(string))))
                {
                    foreach (var prop in GetPropertyInfo(property.PropertyType, viewData, count + 1))
                    {
                        yield return prop;
                    }
                }
            }

        }
    }
}