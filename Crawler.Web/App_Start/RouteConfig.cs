﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Crawler.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}",
				defaults: new {controller = "Root", action = "Root"}
				);
		}
	}
}
