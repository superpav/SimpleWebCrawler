using Crawler.Domain.Entities;

namespace Crawler.UnitTests.Infrastructure
{
	public class SearchEngineParameter
	{
		public SearchEngineType SearchEngineType { get; set; }
		public int Delay { get; set; }
		public string HtmlResult { get; set; }
	}
}
