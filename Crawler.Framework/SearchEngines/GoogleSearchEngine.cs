using Crawler.Domain.Entities;

namespace Crawler.Framework.SearchEngines
{
	public class GoogleSearchEngine : SearchEngineBase
	{
		public const string Url = "https://www.google.ru";
		protected override string SearchUrl => Url + "/search?q={0}";
		public override SearchEngineType EngineType => SearchEngineType.Google;
	}
}
