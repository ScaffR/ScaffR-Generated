namespace DemoApplication.Models.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EnumDropDownAttribute : UIHintAttribute, IDropDownAttribute
    {
        private readonly Type _enumType;

        public EnumDropDownAttribute(Type enumType) :this(enumType, "EnumDropDown")
        {
            _enumType = enumType;
        }

        public EnumDropDownAttribute(Type enumType, string templateName) : base(templateName)
        {
            _enumType = enumType;
        }

        public IEnumerable<SelectListItem> GetMethodResult()
        {
            return Dropdowns.Dropdowns.ForEnum(_enumType);
        }
    }
}