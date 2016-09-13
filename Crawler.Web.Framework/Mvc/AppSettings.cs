using System.Configuration;

namespace Crawler.Web.Framework.Mvc
{
	public class AppSettings
	{
		public static bool IsGoogleEnabled => ConfigurationManager.AppSettings["EnableGoogle"] == "true";
		public static bool IsBingEnabled => ConfigurationManager.AppSettings["EnableBing"] == "true";
		public static bool IsYandexEnabled => ConfigurationManager.AppSettings["EnableYandex"] == "true";
	}
}
