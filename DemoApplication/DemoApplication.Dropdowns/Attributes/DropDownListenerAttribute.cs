namespace DemoApplication.Dropdowns.Attributes
{
    #region

    using System;
    using System.Web.Mvc;

    #endregion

    public class DropDownListenerAttribute : Attribute, IMetadataAware
    {
        private readonly string _parent;
        private readonly string _clientCallback;

        public DropDownListenerAttribute(string parent, string clientCallback)
        {
            _clientCallback = clientCallback;
            _parent = parent;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("dropdownlistener", true);
            metadata.AdditionalValues.Add("dropdownlistener-callback", _clientCallback);
            metadata.AdditionalValues.Add("dropdownlistener-parent", _parent);
        }
    }
}