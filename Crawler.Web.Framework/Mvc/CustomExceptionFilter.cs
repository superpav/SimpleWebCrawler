using System.Web.Mvc;
using NLog;

namespace Crawler.Web.Framework.Mvc
{
	public class CustomExceptionFilter : HandleErrorAttribute
	{
		protected Logger _Logger = LogManager.GetCurrentClassLogger();

		public override void OnException(ExceptionContext filterContext)
		{
			this._Logger.Error(filterContext.Exception, "Необработанное исключение");
			base.OnException(filterContext);
		}
	}
}
