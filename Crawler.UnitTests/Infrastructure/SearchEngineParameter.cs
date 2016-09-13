using Crawler.Domain.Entities;

namespace Crawler.UnitTests.Infrastructure
{
	public class SearchEngineParameter
	{
		public SearchEngineType SearchEngineType { get; set; }
		public int Delay { get; set; }
		public string HtmlResult { get; set; }

		public SearchEngineParameter(SearchEngineType searchEngineType, int delay, string htmlResult)
		{
			this.SearchEngineType = SearchEngineType;
			this.Delay = delay;
			this.HtmlResult = htmlResult;
		}
	}
}
