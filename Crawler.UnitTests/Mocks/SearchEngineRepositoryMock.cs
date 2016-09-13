using System.Collections.Generic;
using System.Linq;
using Crawler.Domain.Integartion.SearchEngineRepositories;
using Crawler.Domain.Integartion.SearchEngines;

namespace Crawler.UnitTests.Mocks
{
	public class SearchEngineRepositoryMock : ISearchEngineRepository
	{
		public IEnumerable<SearchEngineBase> SearchEngines { get; set; }

		public IList<SearchEngineBase> GetEnginesToSearch()
		{
			return this.SearchEngines.ToList();
		}
	}
}