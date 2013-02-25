namespace DemoApplication.Extensions.Sitemap
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using Models.Sitemap;
    using MvcSiteMapProvider;
    using MvcSiteMapProvider.Web.Html;

    /// <summary>
    /// MvcBreadcrumbHtmlHelper extension methods
    /// </summary>
    public static class BreadcrumbExtensions
    {
        /// <summary>
        /// Source metadata
        /// </summary>
        private static Dictionary<string, object> BreadcrumbSourceMetadata = new Dictionary<string, object> { { "HtmlHelper", typeof(BreadcrumbExtensions).FullName } };

        /// <summary>
        /// Gets Breadcrumb path for the current request
        /// </summary>
        /// <param name="helper">MvcBreadcrumbHtmlHelper instance</param>
        /// <returns>Breadcrumb path for the current request</returns>
        public static MvcHtmlString Breadcrumb(this MvcSiteMapHtmlHelper helper)
        {
            return Breadcrumb(helper, null);
        }

        /// <summary>
        /// Gets Breadcrumb path for the current request
        /// </summary>
        /// <param name="helper">MvcBreadcrumbHtmlHelper instance</param>
        /// <param name="templateName">Name of the template.</param>
        /// <returns>Breadcrumb path for the current request</returns>
        public static MvcHtmlString Breadcrumb(this MvcSiteMapHtmlHelper helper, string templateName)
        {
            var model = BuildModel(helper, helper.Provider.CurrentNode);
            return helper
                .CreateHtmlHelperForModel(model)
                .DisplayFor(m => model, "Sitemap/Breadcrumb");
        }

        /// <summary>
        /// Builds the model.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="startingNode">The starting node.</param>
        /// <returns>The model.</returns>
        private static BreadcrumbHelperModel BuildModel(MvcSiteMapHtmlHelper helper, SiteMapNode startingNode)
        {
            // Build model
            var model = new BreadcrumbHelperModel();
            var node = startingNode;
            while (node != null)
            {
                var mvcNode = node as MvcSiteMapNode;

                // Check visibility
                bool nodeVisible = true;
                if (mvcNode != null)
                {
                    nodeVisible = mvcNode.VisibilityProvider.IsVisible(
                        node, HttpContext.Current, BreadcrumbSourceMetadata);
                }

                // Check ACL
                if (nodeVisible && node.IsAccessibleToUser(HttpContext.Current))
                {
                    // Add node
                    var nodeToAdd = SiteMapNodeModelMapper.MapToSiteMapNodeModel(node, mvcNode, BreadcrumbSourceMetadata);
                    model.Nodes.Add(nodeToAdd);
                }
                node = node.ParentNode;
            }
            model.Nodes.Reverse();

            return model;
        }
    }
}
