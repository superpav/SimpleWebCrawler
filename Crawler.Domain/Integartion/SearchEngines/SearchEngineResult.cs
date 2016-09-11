using Crawler.Domain.Entities;

namespace Crawler.Domain.Integartion.SearchEngines
{
	public class SearchEngineResult
	{
		public SearchEngineType EngineType { get; set; }
		public string Result { get; set; }
	}
}
