namespace DemoApplication.Models.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class DropDownAttribute : UIHintAttribute, IDropDownAttribute
    {
        private readonly Type _serviceType;
        protected readonly string _methodName;
        protected readonly object[] _arguments;

        public DropDownAttribute(string methodName, params object[] arguments)
            : this(methodName, "DropDown", typeof(Dropdowns.Dropdowns), arguments)
        {
        }

        public DropDownAttribute(string methodName, string templateName, Type serviceType, params object[] arguments)
            : base(templateName)
        {
            _serviceType = serviceType;
            _methodName = methodName;
            _arguments = arguments;
        }

        public IEnumerable<SelectListItem> GetMethodResult()
        {
            var serviceInstance = Activator.CreateInstance(_serviceType);
            var methodInfo = _serviceType.GetMethod(_methodName);
            return methodInfo.Invoke(serviceInstance, _arguments) as IEnumerable<SelectListItem>;
        }
    }
}