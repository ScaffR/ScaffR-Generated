namespace DemoApplication.Models.Sitemap
{
    using System.Collections;
    using System.Collections.Generic;
    using MvcSiteMapProvider.Web.Html.Models;

    public partial class TabsHelperModel : IEnumerable<SiteMapNodeModel>
    {
        public TabsHelperModel()
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
}