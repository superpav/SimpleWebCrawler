using System.Collections.Generic;
using Crawler.Domain.Integartion.SearchEngines;

namespace Crawler.Domain.Integartion.SearchEngineRepositories
{
	public interface ISearchEngineRepository
	{
		IList<SearchEngineBase> GetEnginesToSearch();
	}
}