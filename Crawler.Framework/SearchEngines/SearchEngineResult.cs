using Crawler.Domain.Entities;

namespace Crawler.Framework.SearchEngines
{
	public class SearchEngineResult
	{
		public SearchEngineType EngineType { get; set; }
		public string Result { get; set; }
	}
}
