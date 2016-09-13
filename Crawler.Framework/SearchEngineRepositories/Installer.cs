using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Crawler.Framework.SearchEngineRepositories
{
	public class Installer : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<ISearchEngineRepository>().ImplementedBy<SearchEngineRepository>());
		}
	}
}
