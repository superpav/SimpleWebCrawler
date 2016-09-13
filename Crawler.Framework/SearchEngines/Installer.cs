using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Crawler.Framework.SearchEngines
{
	public class Installer : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<BingSearchEngine>().ImplementedBy<BingSearchEngine>(),
				Component.For<YandexSearchEngine>().ImplementedBy<YandexSearchEngine>(),
				Component.For<GoogleSearchEngine>().ImplementedBy<GoogleSearchEngine>());
		}
	}
}
