using Crawler.Domain.Entities;

namespace Crawler.Domain.Integartion.SearchEngines
{
	public class GoogleSearchEngine : SearchEngineBase
	{
		protected override string SearchUrl => "https://www.google.ru/search?q={0}";
		public override SearchEngineType EngineType => SearchEngineType.Google;
	}
}
