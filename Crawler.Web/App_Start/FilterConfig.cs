using System.Web.Mvc;
using Crawler.Web.Framework.Mvc;

namespace Crawler.Web.App_Start
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new CustomExceptionFilter());
		}
	}
}