using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;

namespace Crawler.Web.Framework.IoC
{
	public class CustomDependecyResolver : IDependencyResolver
	{
		private readonly WindsorContainer _container;

		public CustomDependecyResolver(WindsorContainer container)
		{
			this._container = container;
		}

		public object GetService(Type serviceType)
		{
			return this._container.Kernel.HasComponent(serviceType)
				? this._container.Resolve(serviceType)
				: null;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this._container.Kernel.HasComponent(serviceType)
				? this._container.ResolveAll(serviceType).Cast<object>()
				: Enumerable.Empty<object>();
		}
	}
}