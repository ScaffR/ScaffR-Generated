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
namespace DemoApplication.Application.Startup
{
    #region

    using System.IO;
    using Cassette;
    using Cassette.Scripts;
    using Cassette.Stylesheets;

    #endregion

    /// <summary>
    /// Class AppStartup
    /// </summary>
    public partial class AppStartup : IConfiguration<BundleCollection>
	{
        /// <summary>
        /// Configures the specified configurable.
        /// </summary>
        /// <param name="configurable">The configurable.</param>
		public void Configure(BundleCollection configurable)
		{
			configurable.AddPerSubDirectory<ScriptBundle>("Scripts", new FileSearch()
			{
				SearchOption = SearchOption.TopDirectoryOnly
			});
		
			configurable.Add<StylesheetBundle>("content/less/site.less");

			configurable.AddPerSubDirectory<ScriptBundle>("Scripts/lib");

            configurable.AddUrlWithAlias<ScriptBundle>("http://maps.google.com/maps/api/js?sensor=false&libraries=places", "googleMaps");
		}
	}
}