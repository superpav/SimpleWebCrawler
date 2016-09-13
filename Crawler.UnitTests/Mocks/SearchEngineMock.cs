using System;
using System.Threading;
using System.Threading.Tasks;
using Crawler.Domain.Entities;
using Crawler.Domain.Integartion.SearchEngines;

namespace Crawler.UnitTests.Mocks
{
	public class SearchEngineMock : SearchEngineBase
	{
		public override SearchEngineType EngineType { get; }
		protected override string SearchUrl => String.Empty;
		private readonly int _delay;
		private readonly string _htmlResult;

		public SearchEngineMock(SearchEngineType searchEngineType, int delay)
		{
			this.EngineType = searchEngineType;
			this._delay = delay;
			this._htmlResult = String.Empty;
		}

		public SearchEngineMock(SearchEngineType searchEngineType, int delay, string htmlResult)
			: this(searchEngineType, delay)
		{
			this._htmlResult = htmlResult;
		}

		public override async Task<SearchEngineResult> SearchAsync(string query, CancellationToken cancellationToken)
		{
			await Task.Delay(this._delay, cancellationToken);

			return new SearchEngineResult
			{
				EngineType = this.EngineType,
				Result = this._htmlResult
			};
		}
	}
}