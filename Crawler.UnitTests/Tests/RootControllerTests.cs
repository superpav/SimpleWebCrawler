using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Crawler.Domain.Entities;
using Crawler.Domain.Integartion.SearchProcessors;
using Crawler.UnitTests.Mocks;
using Crawler.Web.Controllers;
using Crawler.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crawler.UnitTests.Tests
{
	[TestClass]
	public class RootControllerTests
	{
		private DbContextMock _dbContext;

		[TestInitialize]
		public void TestInitialize()
		{
			this._dbContext = new DbContextMock();
		}

		[TestMethod]
		public void If_Model_State_Is_Invalid_Search_Action_Should_Return_Bad_Request()
		{
			// Arrange
			var model = new SearchFormModel();
			var controller = new RootController(null, this._dbContext);

			// Act
			controller.ModelState.AddModelError(String.Empty, String.Empty);
			var result = controller.Search(model).Result;

			// Assert
			var httpStatusCodeResult = result as HttpStatusCodeResult;

			Assert.IsNotNull(httpStatusCodeResult);
			Assert.AreEqual(httpStatusCodeResult.StatusCode, (int)HttpStatusCode.BadRequest);
		}

		[TestMethod]
		public void If_There_Are_No_Results_Search_Action_Should_Return_Empty_Result()
		{
			// Arrange
			var model = new SearchFormModel();
			var searchEngines = new List<SearchEngineMock>
			{
				new SearchEngineMock(SearchEngineType.Bing, 2000),
				new SearchEngineMock(SearchEngineType.Yandex, 1500),
				new SearchEngineMock(SearchEngineType.Google, 1000)
			};

			var searchEngineRepository = new SearchEngineRepositoryMock
			{
				SearchEngines = searchEngines
			};

			var searchProcessor = new SearchProcessor(searchEngineRepository);
			var controller = new RootController(searchProcessor, this._dbContext);

			// Act
			var result = controller.Search(model).Result;

			// Assert
			Assert.IsInstanceOfType(result, typeof (EmptyResult));
		}

		[TestMethod]
		public void If_There_Are_Any_Results_In_Search_They_Should_Be_Saved()
		{
			// Arrange
			var model = new SearchFormModel
			{
				Query = "test"
			};

			var searchEngines = new List<SearchEngineMock>
			{
				new SearchEngineMock(SearchEngineType.Bing, 2000, Resources.BingPage),
				new SearchEngineMock(SearchEngineType.Yandex, 1500, Resources.YandexPage),
				new SearchEngineMock(SearchEngineType.Google, 1000, Resources.GooglePage)
			};

			var searchEngineRepository = new SearchEngineRepositoryMock
			{
				SearchEngines = searchEngines
			};

			var searchProcessor = new SearchProcessor(searchEngineRepository);
			var controller = new RootController(searchProcessor, this._dbContext);

			// Act
			var result = controller.Search(model).Result;

			// Assert
			var partialViewResult = result as PartialViewResult;

			Assert.IsNotNull(partialViewResult);
			Assert.AreEqual(partialViewResult.ViewName, "SearchResults");
			Assert.IsNotNull(partialViewResult.Model);

			Assert.IsTrue(this._dbContext.SearchQuery.Any());
		}

		[TestMethod]
		public void If_Offset_Provided_Then_Result_Shoul_Be_Filtered()
		{
			// Arrange
			var viewModel = new SearchFormModelWithOffset
			{
				Query = "test",
				Offset = 2
			};

			var searchQuery = this.GetTestSeqrchQuery();
			var searchResult1 = this.GetTestSearchResult(1, searchQuery);
			var searchResult2 = this.GetTestSearchResult(2, searchQuery);

			this._dbContext.SearchQuery.Add(searchQuery);
			this._dbContext.SearchResult.Add(searchResult1);
			this._dbContext.SearchResult.Add(searchResult2);

			var controller = new RootController(null, this._dbContext);

			// Act
			var result = controller.SearchHistory(viewModel);

			// Assert
			var partialViewResult = result as PartialViewResult;

			Assert.IsNotNull(partialViewResult);
			Assert.AreEqual(partialViewResult.ViewName, "SearchResults");
			Assert.IsNotNull(partialViewResult.Model);

			var model = (IEnumerable<SearchResult>)partialViewResult.Model;
			Assert.IsTrue(model.All(x => x.Id == 1));
		}

		private SearchQuery GetTestSeqrchQuery()
		{
			return new SearchQuery {Query = "test"};
		}

		private SearchResult GetTestSearchResult(int id, SearchQuery searchQuery)
		{
			return new SearchResult
			{
				Id = id,
				Description = "Descitpion",
				Link = "Link",
				Title = "Title",
				SearchEngineType = SearchEngineType.Bing,
				SearchQuery = searchQuery
			};
		}
	}
}
