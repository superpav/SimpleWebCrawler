using System.Web.Mvc;
using Castle.Windsor;

namespace Crawler.Web.Framework.IoC
{
	public class CustomControllerFactory : DefaultControllerFactory
	{
		private readonly WindsorContainer _container;

		public CustomControllerFactory(WindsorContainer container)
		{
			this._container = container;
		}

		public override void ReleaseController(IController controller)
		{
			base.ReleaseController(controller);
			this._container.Release(controller);
		}
	}
}
