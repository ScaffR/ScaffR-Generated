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

    public class VideoAttribute : DataTypeAttribute, IMetadataAware
    {

        private VideoEmbedding _embedding = VideoEmbedding.Flash;
        private VideoType _videoType;
        private bool _autoPlay;
        private int _width = 640;
        private int _height = 360;
        private string _poster;
        private string _title;

        public VideoAttribute()
            : this("Video")
        {

        }

        public VideoAttribute(DataType dataType) : base(dataType)
        {
            
        }

        public VideoAttribute(string dataType)
            : base(dataType)
        {

        }

        public VideoEmbedding VideoEmbedding
        {
            get { return _embedding; }
            set { _embedding = value; }
        }

        public bool AutoPlay
        {
            get { return _autoPlay; }
            set { _autoPlay = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public VideoType VideoType
        {
            get { return _videoType; }
            set { _videoType = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Poster
        {
            get { return _poster; }
            set { _poster = value; }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["embedding"] = _embedding;
            metadata.AdditionalValues["videoType"] = _videoType;
            metadata.AdditionalValues["autoplay"] = _autoPlay;
            metadata.AdditionalValues["width"] = _width;
            metadata.AdditionalValues["height"] = _height;            
            metadata.AdditionalValues["title"] = _title;
            metadata.AdditionalValues["poster"] = _poster;

        }
    }

}