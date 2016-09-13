using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Crawler.Domain.Entities;

namespace Crawler.Domain.Integartion.SearchEngines
{
	public abstract class SearchEngineBase
	{
		protected abstract string SearchUrl { get; }
		public abstract SearchEngineType EngineType { get; }

		public virtual async Task<SearchEngineResult> SearchAsync(string query, CancellationToken cancellationToken)
		{
			var url = String.Format(this.SearchUrl, query);

			using (var client = new HttpClient())
			using (var httpResponse = await client.GetAsync(url, cancellationToken))
			{
				return new SearchEngineResult
				{
					EngineType = this.EngineType,
					Result = await httpResponse.Content.ReadAsStringAsync()
				};
			}
		}
	}
}
