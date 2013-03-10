namespace DemoApplication.Dropdowns.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EnumDropDownAttribute : DropDownAttribute
    {
        private readonly Type _enumType;

        public EnumDropDownAttribute(Type enumType)
            : this(enumType, "ForEnum" )
        {
            _enumType = enumType;
        }

        public bool IsMultiselect { get; set; }

        public EnumDropDownAttribute(Type enumType, string templateName) : base(templateName, enumType)
        {
            IsMultiselect = false;
            _enumType = enumType;
        }

        public IEnumerable<SelectListItem> GetMethodResult(Type enumType)
        {
            var serviceInstance = Activator.CreateInstance(_enumType);
            var methodInfo = _enumType.GetMethod(_methodName);

            return methodInfo.Invoke(serviceInstance, new object[] {enumType}) as IEnumerable<SelectListItem>;
        }

        public override void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("methodName", _methodName);
            metadata.AdditionalValues.Add("enumName", _enumType);

            base.OnMetadataCreated(metadata);
        }
    }
}