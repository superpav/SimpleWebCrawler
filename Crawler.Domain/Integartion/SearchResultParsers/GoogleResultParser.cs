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

			var url = link.Attr("href").Replace("/url?q=", String.Empty);
			var paramtersIndex = url.IndexOf("&sa=", StringComparison.InvariantCulture);

			if (paramtersIndex != -1)
				url = url.Remove(paramtersIndex);

			return new ParsedSearchEngineResult
			{
				Title = link.Text(),
				Url = url,
				Desciption = descriptionElement.Text()
			};
		}
	}
}
