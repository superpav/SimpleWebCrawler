using System;
using Crawler.Domain.Entities;

namespace Crawler.Domain.Integartion.SearchResultParsers
{
	public class SearchResultParserFactory
	{
		public SearchResultParserBase CreateParser(SearchEngineType searchEngineType)
		{
			switch (searchEngineType)
			{
				case SearchEngineType.Bing:
					return new BingResultParser();
				case SearchEngineType.Google:
					return new GoogleResultParser();
				case SearchEngineType.Yandex:
					return new YandexResultParser();

				default:
					throw new ArgumentOutOfRangeException(nameof(searchEngineType));
			}
		}
	}
}
