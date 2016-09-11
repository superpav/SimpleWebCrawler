using System.Web.Mvc;
using Castle.MicroKernel;

namespace Crawler.Web.Framework.IoC
{
	public class CustomControllerFactory : DefaultControllerFactory
	{
		private readonly IKernel _kernel;

		public CustomControllerFactory(IKernel kernel)
		{
			this._kernel = kernel;
		}

		public override void ReleaseController(IController controller)
		{
			this._kernel.ReleaseComponent(controller);
		}
	}
}
