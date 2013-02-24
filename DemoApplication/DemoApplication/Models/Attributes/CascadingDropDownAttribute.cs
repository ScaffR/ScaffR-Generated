namespace DemoApplication.Models.Attributes
{
    using System.Web.Mvc;

    public class CascadingDropDownAttribute : DropDownAttribute, IMetadataAware
    {
        private string _parentName;

        public CascadingDropDownAttribute(string parentName, string methodName, params object[] arguments) : base(methodName, arguments)
        {
            _parentName = parentName;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("parentName", _parentName);
            metadata.AdditionalValues.Add("methodName", _methodName);
        }
    }
}