using System.Web.Optimization;

namespace Crawler.Web.App_Start
{
	public class BundleConfig
	{
		public const string StylesBundleName = "~/css";
		public const string ScriptsBundleName = "~/js";

		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle(StylesBundleName).Include("~/Content/css/Styles.css"));

			bundles.Add(new ScriptBundle(ScriptsBundleName)
				.Include("~/Content/js/Root.js")
				.Include("~/Content/js/SearchForm.js"));
		}
	}
}
