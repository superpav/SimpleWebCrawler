using System;
using System.Collections.Generic;
using System.Linq;
using Crawler.Domain.Entities;
using Crawler.Domain.Integartion.SearchProcessors;
using Crawler.UnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crawler.UnitTests.Tests
{
	[TestClass]
	public class SearchProcessorTests
	{
		[TestMethod]
		public void Only_Results_From_Fastest_Search_Engine_Should_Be_Processed()
		{
			const int bingDelay = 2000;
			const int yandexDelay = 1500;
			const int googleDelay = 1000;

			// Arrange
			var searchEngineParameters = new Dictionary<SearchEngineType, int>
			{
				{SearchEngineType.Bing, bingDelay},
				{SearchEngineType.Yandex, yandexDelay},
				{SearchEngineType.Google, googleDelay}
			};

			var availableSearchEngines =
				searchEngineParameters.Select(
					searchEngineParameter => new SearchEngineMock(searchEngineParameter.Key, searchEngineParameter.Value)).ToList();

			var searchEngineRepository = new SearchEngineRepositoryMock
			{
				SearchEngines = availableSearchEngines
			};

			var searchProcessor = new SearchProcessor(searchEngineRepository);

			// Act
			var result = searchProcessor.SearchAsync(String.Empty).Result;

			// Assert
			var fastestSearchEngine = searchEngineParameters.OrderBy(x => x.Value).First();

			Assert.AreEqual(fastestSearchEngine.Key, result.EngineType);
		}
	}
}
