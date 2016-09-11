using System.Web.Mvc;

namespace Crawler.Web.Controllers
{
	public class RootController : Controller
	{
		public ActionResult Root()
		{
			return new ContentResult {Content = "test"};
		}
	}
}