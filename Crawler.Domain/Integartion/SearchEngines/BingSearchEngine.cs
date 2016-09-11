using Crawler.Domain.Entities;

namespace Crawler.Domain.Integartion.SearchEngines
{
	public class BingSearchEngine : SearchEngineBase
	{
		protected override string SearchUrl => "https://www.bing.ru/search?q={0}";
		public override SearchEngineType EngineType => SearchEngineType.Bing;
	}
}
