using System.Collections.Generic;
using Crawler.Framework.SearchEngines;

namespace Crawler.Framework.SearchEngineRepositories
{
	public interface ISearchEngineRepository
	{
		IList<SearchEngineBase> GetEnginesToSearch();
	}
}