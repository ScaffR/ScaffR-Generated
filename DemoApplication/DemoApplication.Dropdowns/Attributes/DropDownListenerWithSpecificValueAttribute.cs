namespace DemoApplication.Dropdowns.Attributes
{
    #region

    using System;
    using System.Web.Mvc;

    #endregion

    public class DropDownListenerWithSpecificValueAttribute : Attribute, IMetadataAware
    {
        private readonly string _matchingValue;
        private readonly string _parent;
        private readonly string _clientCallback;

        public DropDownListenerWithSpecificValueAttribute(string parent, string matchingValue, string clientCallback)
        {
            _clientCallback = clientCallback;
            _parent = parent;
            _matchingValue = matchingValue;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("dropdownlistenerwithspecificvalue", true);
            metadata.AdditionalValues.Add("dropdownlistenerwithspecificvalue-match", _matchingValue);
            metadata.AdditionalValues.Add("dropdownlistenerwithspecificvalue-callback", _clientCallback);
            metadata.AdditionalValues.Add("dropdownlistenerwithspecificvalue-parent", _parent);
        }
    }
}