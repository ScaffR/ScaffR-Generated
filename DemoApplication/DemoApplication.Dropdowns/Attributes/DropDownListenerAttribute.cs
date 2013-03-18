#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
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