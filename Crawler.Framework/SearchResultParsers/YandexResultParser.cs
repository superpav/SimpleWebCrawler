using System.Collections.Generic;
using System.Linq;
using CsQuery;

namespace Crawler.Framework.SearchResultParsers
{
	public class YandexResultParser : SearchResultParserBase
	{
		protected override IEnumerable<IDomObject> GetItems(CQ document)
		{
			return document.Find(".serp-list li.serp-item").Take(10);
		}

		protected override ParsedSearchEngineResult ParseItem(IDomObject domObject)
		{
			var searchItemCq = domObject.Cq();
			var link = searchItemCq.Find(".serp-item__title > a").First();
			var descriptionElement = searchItemCq.Find(".organic__text");

			return new ParsedSearchEngineResult
			{
				Title = link.Text(),
				Url = link.Attr("href"),
				Desciption = descriptionElement.Text()
			};
		}
	}
}
