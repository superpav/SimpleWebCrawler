using System.Linq;
using Crawler.Domain.Entities;
using Crawler.Domain.Integartion.SearchResultParsers;
using Crawler.UnitTests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crawler.UnitTests.Tests
{
	[TestClass]
	public class SearchResultParserTests
	{
		[TestMethod]
		public void All_Links_From_Bing_Search_Should_Be_Valid()
		{
			this.All_Links_From_Search_Engine_Should_Be_Valid(SearchEngineType.Bing, Resources.BingPage);
		}

		[TestMethod]
		public void All_Links_From_Google_Search_Should_Be_Valid()
		{
			this.All_Links_From_Search_Engine_Should_Be_Valid(SearchEngineType.Google, Resources.GooglePage);
		}

		[TestMethod]
		public void All_Links_From_Yandex_Search_Should_Be_Valid()
		{
			this.All_Links_From_Search_Engine_Should_Be_Valid(SearchEngineType.Yandex, Resources.YandexPage);
		}

		private void All_Links_From_Search_Engine_Should_Be_Valid(SearchEngineType searchEngineType, string htmlPage)
		{
			// Arrange
			var searchParser = SearchResultParserFactory.CreateParser(searchEngineType);

			// Act
			var results = searchParser.Parse(htmlPage);

			// Assert
			Assert.IsTrue(results.All(x => x.Url.IsValidUrl()));
		}
	}
}
