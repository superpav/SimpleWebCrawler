using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Crawler.Web.App_Start;
using Crawler.Web.Framework.IoC;

namespace Crawler.Web
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			WindsorConfig.ConfigureWindsor();
		}

		protected void Application_End()
		{
			Container.Current.Dispose();
		}
	}
}
