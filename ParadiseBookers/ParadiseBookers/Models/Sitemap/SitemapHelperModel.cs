#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-04-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Collections;
using System.Collections.Generic;
using MvcSiteMapProvider.Web.Html.Models;

namespace ParadiseBookers.Models.Sitemap
{
    #region

    

    #endregion

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

    public partial class MainMenuSitemapHelperModel : IEnumerable<SiteMapNodeModel>
    {
        public MainMenuSitemapHelperModel()
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