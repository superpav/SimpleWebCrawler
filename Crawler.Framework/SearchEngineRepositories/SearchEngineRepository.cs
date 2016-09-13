using System.Collections.Generic;
using Crawler.Framework.SearchEngines;
using Crawler.Web.Framework.Mvc;

namespace Crawler.Framework.SearchEngineRepositories
{
	public class SearchEngineRepository : ISearchEngineRepository
	{
		public GoogleSearchEngine Google { get; set; }
		public YandexSearchEngine Yandex { get; set; }
		public BingSearchEngine Bing { get; set; }

		public IList<SearchEngineBase> GetEnginesToSearch()
		{
			var result = new List<SearchEngineBase>();

			if( AppSettings.IsGoogleEnabled )
				result.Add( this.Google );

			if(AppSettings.IsBingEnabled)
				result.Add( this.Bing );

			if( AppSettings.IsYandexEnabled )
				result.Add( this.Yandex );

			return result;
		}
	}
}
