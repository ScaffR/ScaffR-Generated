namespace DemoApplication.Bootstrappers
{
	using System.IO;
	using Cassette;
	using Cassette.Scripts;
	using Cassette.Stylesheets;

	public partial class Bootstrapper : IConfiguration<BundleCollection>
	{
		public void Configure(BundleCollection configurable)
		{
			configurable.AddPerSubDirectory<ScriptBundle>("Scripts", new FileSearch()
			{
				SearchOption = SearchOption.TopDirectoryOnly
			});
		
			configurable.Add<StylesheetBundle>("content/less/site.less");
			configurable.AddPerSubDirectory<ScriptBundle>("Scripts/custom");

			configurable.AddPerSubDirectory<ScriptBundle>("Scripts/lib");

            configurable.AddUrlWithAlias<ScriptBundle>("http://maps.google.com/maps/api/js?sensor=false&libraries=places", "googleMaps");
		}
	}
}