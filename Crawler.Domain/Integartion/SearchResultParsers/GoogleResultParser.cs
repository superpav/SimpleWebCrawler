using System;
using System.Collections.Generic;
using System.Linq;
using CsQuery;

namespace Crawler.Domain.Integartion.SearchResultParsers
{
	public class GoogleResultParser : SearchResultParserBase
	{
		protected override IEnumerable<IDomObject> GetItems(CQ document)
		{
			return document.Find("#res .g").Take(10);
		}

		protected override ParsedSearchEngineResult ParseItem(IDomObject domObject)
		{
			var searchItemCq = domObject.Cq();
			var link = searchItemCq.Find(".r a").First();
			var descriptionElement = searchItemCq.Find(".s span.st");

			return new ParsedSearchEngineResult()
			{
				Title = link.Text(),
				Url = link.Attr("href").Replace("/url?q=", String.Empty),
				Desciption = descriptionElement.Text()
			};
		}
	}
}
