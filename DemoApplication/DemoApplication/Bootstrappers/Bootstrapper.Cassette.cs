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

			//configurable.AddPerSubDirectory<StylesheetBundle>("content/less");
			configurable.Add<StylesheetBundle>("content/less/site.less");
			configurable.AddPerSubDirectory<ScriptBundle>("Scripts/custom");

			configurable.AddPerSubDirectory<ScriptBundle>("Scripts/lib");
		}
	}
}