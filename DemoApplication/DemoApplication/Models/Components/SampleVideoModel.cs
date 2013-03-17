#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-07-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Models.Components
{
    #region

    using Metadata.Attributes;

    #endregion

    public class SampleVideoModel
    {

        [Video(VideoEmbedding = VideoEmbedding.Html5, VideoType = VideoType.Youtube, AutoPlay = true)]
        public VideoModel YoutubeHtml5 { get; set; }

        [Video(VideoEmbedding = VideoEmbedding.Flash, VideoType = VideoType.Youtube, AutoPlay = false)]
        public VideoModel YoutubeFlash { get; set; }

        [Video(VideoEmbedding = VideoEmbedding.Html5, VideoType = VideoType.MP4, AutoPlay = true, Width = 600)]
        public VideoModel Mp4Html5 { get; set; }

    }

    public class VideoModel
    {

        public string Source { get; set; }

    }
   
}