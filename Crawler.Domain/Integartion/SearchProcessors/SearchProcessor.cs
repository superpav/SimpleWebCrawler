using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Crawler.Domain.Entities;
using Crawler.Domain.Integartion.SearchEngineRepositories;
using Crawler.Domain.Integartion.SearchEngines;

namespace Crawler.Domain.Integartion.SearchProcessors
{
	public class SearchProcessor : ISearchProcessor
	{
		private readonly ISearchEngineRepository _searchEngineRepository;

		public SearchProcessor(ISearchEngineRepository searchEngineRepository)
		{
			this._searchEngineRepository = searchEngineRepository;
		}

		private IDictionary<SearchEngineType, CancellationTokenSource> GetCancellationTokensForEngines(
			IEnumerable<SearchEngineBase> searchEngines)
		{
			return searchEngines.ToDictionary(searchEngine => searchEngine.EngineType,
				searchEngine => new CancellationTokenSource());
		}

		private void CancellDeprecatedTasks(SearchEngineResult searchResult,
			IDictionary<SearchEngineType, CancellationTokenSource> cancellationTokens)
		{
			var deprecatedTasks = cancellationTokens.Where(x => x.Key != searchResult.EngineType);

			foreach (var deprecatedTask in deprecatedTasks)
			{
				deprecatedTask.Value.Cancel();
			}
		}

		public async Task<SearchEngineResult> SearchAsync(string query)
		{
			var searchEngines = this._searchEngineRepository.GetEnginesToSearch();
			var cancellationTokens = this.GetCancellationTokensForEngines(searchEngines);

			var tasks = searchEngines.Select(x => x.SearchAsync(query, cancellationTokens[x.EngineType].Token));

			var resultTask = await Task.WhenAny(tasks);
			var result = resultTask.Result;

			this.CancellDeprecatedTasks(result, cancellationTokens);

			return result;
		}
	}
}
