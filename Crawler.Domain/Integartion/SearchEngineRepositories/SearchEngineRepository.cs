using System.Collections.Generic;
using Crawler.Domain.Integartion.SearchEngines;

namespace Crawler.Domain.Integartion.SearchEngineRepositories
{
	public class SearchEngineRepository : ISearchEngineRepository
	{
		public GoogleSearchEngine Google { get; set; }
		public YandexSearchEngine Yandex { get; set; }
		public BingSearchEngine Bing { get; set; }

		public IList<SearchEngineBase> GetEnginesToSearch()
		{
			return new List<SearchEngineBase>
			{
				this.Google,
				this.Yandex,
				this.Bing
			};
		}
	}
}
