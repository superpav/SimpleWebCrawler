using System.Web.Mvc;
using Castle.Windsor.Installer;
using Crawler.Web.Framework.IoC;

namespace Crawler.Web.App_Start
{
	public class WindsorConfig
	{
		public static void ConfigureWindsor()
		{
			Container.Current.Install(FromAssembly.InThisApplication());

			var controllerFactory = new CustomControllerFactory(Container.Current.Kernel);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);

			var customDependecyResolver = new CustomDependecyResolver(Container.Current);
			DependencyResolver.SetResolver(customDependecyResolver);
		}
	}
}