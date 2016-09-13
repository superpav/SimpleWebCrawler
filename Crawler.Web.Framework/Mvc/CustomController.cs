using System.Web.Mvc;
using Crawler.Domain.Entities;

namespace Crawler.Web.Framework.Mvc
{
	public class CustomController : Controller
	{
		protected readonly ICrawlerContext DbContext;

		public CustomController(ICrawlerContext dbContext)
		{
			this.DbContext = dbContext;
		}
	}
}
