using System.Collections.Generic;
using System.Linq;
using CsQuery;

namespace Crawler.Framework.SearchResultParsers
{
	public abstract class SearchResultParserBase
	{
		protected abstract IEnumerable<IDomObject> GetItems(CQ document);

		protected abstract ParsedSearchEngineResult ParseItem(IDomObject domObject);

		public IEnumerable<ParsedSearchEngineResult> Parse(string htmlContent)
		{
			var document = CQ.CreateDocument(htmlContent);
			var searchItems = this.GetItems(document);

			return searchItems.Select(searchItem => this.ParseItem(searchItem));
		}
	}
}
