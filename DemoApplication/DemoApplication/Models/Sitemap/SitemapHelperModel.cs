namespace DemoApplication.Models.Sitemap
{
    using System.Collections;
    using System.Collections.Generic;
    using MvcSiteMapProvider.Web.Html.Models;

    public partial class SitemapHelperModel : IEnumerable<SiteMapNodeModel>
    {
        public SitemapHelperModel()
        {
            Nodes = new List<SiteMapNodeModel>();
        }

        public List<SiteMapNodeModel> Nodes { get; set; }

        public IEnumerator<SiteMapNodeModel> GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }
    }

    public partial class MainMenuSitemapHelperModel : IEnumerable<CustomNodeModel>
    {
        public MainMenuSitemapHelperModel()
        {
            Nodes = new List<CustomNodeModel>();
        }

        public List<CustomNodeModel> Nodes { get; set; }

        public IEnumerator<CustomNodeModel> GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }
    }
}