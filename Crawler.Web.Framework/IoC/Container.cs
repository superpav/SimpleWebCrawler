using Castle.Windsor;

namespace Crawler.Web.Framework.IoC
{
	public class Container
	{
		public static readonly WindsorContainer Current = new WindsorContainer();
	}
}
