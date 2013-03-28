#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Metadata.Attributes
{
    #region

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    #endregion

    public class CKEditorAttribute : DataTypeAttribute, IMetadataAware
    {
        private bool _useCKFinder = false;
        private string _class = string.Empty;
        private CKEditorToolbar _toolbalConfig = CKEditorToolbar.Default;

        public CKEditorAttribute()
            : this("CKEditor")
        {

        }

        public CKEditorAttribute(DataType dataType) : base(dataType)
        {
            
        }

        public CKEditorAttribute(string dataType)
            : base(dataType)
        {

        }

        public bool UseCKFinder
        {
            get { return _useCKFinder; }
            set { _useCKFinder = value; }
        }

        public CKEditorToolbar ToolBar
        {
            get { return _toolbalConfig; }
            set { _toolbalConfig = value; }
        }

        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["class"] = _class;
            metadata.AdditionalValues["ckfinder"] = UseCKFinder.ToString();
            metadata.AdditionalValues["toolbar-config"] = _toolbalConfig;

        }
    }

}