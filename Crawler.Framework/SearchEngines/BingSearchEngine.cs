using Crawler.Domain.Entities;

namespace Crawler.Framework.SearchEngines
{
	public class BingSearchEngine : SearchEngineBase
	{
		protected override string SearchUrl => "https://www.bing.ru/search?q={0}";
		public override SearchEngineType EngineType => SearchEngineType.Bing;
	}
}
