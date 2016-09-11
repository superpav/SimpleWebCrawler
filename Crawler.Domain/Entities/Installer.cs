using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Crawler.Domain.Entities
{
	public class Installer : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<ICrawlerContext>().ImplementedBy<CrawlerContext>().LifestyleTransient());
		}
	}
}
