using System;
using System.Collections.Generic;
using System.Linq;
using Crawler.Framework.SearchEngines;
using CsQuery;

namespace Crawler.Framework.SearchResultParsers
{
	public class GoogleResultParser : SearchResultParserBase
	{
		protected override IEnumerable<IDomObject> GetItems(CQ document)
		{
			return document.Find("#res .g").Where(x => x.HasChildren).Take(10);
		}

		protected override ParsedSearchEngineResult ParseItem(IDomObject domObject)
		{
			var searchItemCq = domObject.Cq();
			var link = searchItemCq.Find(".r a").First();
			var descriptionElement = searchItemCq.Find(".s span.st");

			return new ParsedSearchEngineResult
			{
				Title = link.Text(),
				Url = this.ParseUrl(link),
				Desciption = descriptionElement.Text()
			};
		}

		private string ParseUrl(CQ link)
		{
			var url = link.Attr("href").Replace("/url?q=", String.Empty);

			if (url.StartsWith("/search"))
				return GoogleSearchEngine.Url + url;

			var paramtersIndex = url.IndexOf("&sa=", StringComparison.InvariantCulture);

			if (paramtersIndex != -1)
				return url.Remove(paramtersIndex);

			return url;
		}
	}
}
