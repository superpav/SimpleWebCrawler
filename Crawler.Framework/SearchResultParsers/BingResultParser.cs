using System.Collections.Generic;
using System.Linq;
using CsQuery;

namespace Crawler.Framework.SearchResultParsers
{
	public class BingResultParser : SearchResultParserBase
	{
		protected override IEnumerable<IDomObject> GetItems(CQ document)
		{
			return document.Find("#b_results li.b_algo").Take(10);
		}

		protected override ParsedSearchEngineResult ParseItem(IDomObject domObject)
		{
			var searchItemCq = domObject.Cq();
			var link = searchItemCq.Find("h2 > a");
			var descriptionElement = searchItemCq.Find(".b_caption > p");

			return new ParsedSearchEngineResult
			{
				Title = link.Text(),
				Url = link.Attr("href"),
				Desciption = descriptionElement.First().Text()
			};
		}
	}
}
