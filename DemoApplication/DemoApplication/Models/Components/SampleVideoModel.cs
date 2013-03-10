namespace DemoApplication.Models.Components
{
    using Metadata.Attributes;

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