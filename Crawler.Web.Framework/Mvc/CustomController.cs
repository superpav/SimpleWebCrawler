using System.Web.Mvc;
using Crawler.Domain.Entities;

namespace Crawler.Web.Framework.Mvc
{
	public class CustomController : Controller
	{
		public ICrawlerContext DbContext { get; set; }
	}
}
