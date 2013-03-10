namespace DemoApplication.Dropdowns.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class DropDownAttribute : UIHintAttribute, IDropDownAttribute, IMetadataAware
    {
        protected readonly Type _serviceType;
        protected readonly string _methodName;
        protected string _dependsOn;
        protected readonly object[] _arguments;
        private DropdownSize _textboxSize = DropdownSize.XLarge;

        public DropDownAttribute(string methodName, params object[] arguments)
            : this(methodName, "DropDown", DependencyResolver.Current.GetService<IDropdownProvider>().GetType(), arguments)
        {
        }

        public string DependsOn
        {
            get { return _dependsOn; }
            set { _dependsOn = value; }
        }

        protected virtual object[] GetArguments()
        {
            return _arguments;
        }

        public DropDownAttribute(string methodName, string templateName, Type serviceType, params object[] arguments)
            : base(templateName)
        {
            _serviceType = serviceType;
            _methodName = methodName;
            _arguments = arguments;
        }

        public DropdownSize TextboxSize
        {
            get { return _textboxSize; }
            set { _textboxSize = value; }
        }

        public IEnumerable<SelectListItem> GetMethodResult()
        {
            var serviceInstance = Activator.CreateInstance(_serviceType);
            var methodInfo = _serviceType.GetMethod(_methodName);
            return methodInfo.Invoke(serviceInstance, GetArguments()) as IEnumerable<SelectListItem>;
        }

        public IEnumerable<SelectListItem> GetMethodResult(object parentValue)
        {
            var serviceInstance = Activator.CreateInstance(_serviceType);
            var methodInfo = _serviceType.GetMethod(_methodName);

            return methodInfo.Invoke(serviceInstance, new[] { parentValue }) as IEnumerable<SelectListItem>;
        }

        public virtual void OnMetadataCreated(ModelMetadata metadata)
        {

        }
    }
}