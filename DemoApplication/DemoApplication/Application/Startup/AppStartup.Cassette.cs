namespace DemoApplication.Application.Startup
{
    using System.IO;
    using Cassette;
    using Cassette.Scripts;
    using Cassette.Stylesheets;
    using Cassette.Views;

    public partial class AppStartup : IConfiguration<BundleCollection>
	{
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