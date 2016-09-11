using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Crawler.Domain.Entities;
using Crawler.Domain.Integartion.SearchProcessors;
using Crawler.Domain.Integartion.SearchResultParsers;
using Crawler.Web.Framework.Mvc;
using Crawler.Web.ViewModels;
using NLog;

namespace Crawler.Web.Controllers
{
	public class RootController : CustomController
	{
		public ISearchProcessor SearchProcessor { get; set; }

		protected Logger Logger = LogManager.GetCurrentClassLogger();

		public ActionResult Root()
		{
			return this.View(SearchType.New);
		}

		public ActionResult History()
		{
			return this.View("Root", SearchType.History);
		}

		[ChildActionOnly]
		public ActionResult SearchForm(SearchType searchType)
		{
			this.ViewBag.SearchType = searchType;

			return this.PartialView();
		}

		[HttpPost]
		public async Task<ActionResult> Search(SearchFormModel model)
		{
			if (!ModelState.IsValid)
				return null;

			var searchResult = await this.SearchProcessor.SearchAsync(model.Query);
			var searchResultParser = SearchResultParserFactory.CreateParser(searchResult.EngineType);
			var parsedResults = searchResultParser.Parse(searchResult.Result).ToList();

			if (parsedResults.Count == 0)
				return null;

			var searchQuery = new SearchQuery
			{
				Query = model.Query
			};

			foreach (var result in parsedResults)
			{
				searchQuery.SearchResult.Add(new SearchResult
				{
					Link = result.Url ?? String.Empty,
					Title = result.Title ?? String.Empty,
					Description = result.Desciption ?? String.Empty,
					SearchEngineType = searchResult.EngineType
				});
			}

			this.DbContext.SearchQuery.Add(searchQuery);

			await this.DbContext.SaveChangesAsync();

			return this.PartialView("SearchResults", searchQuery.SearchResult.AsEnumerable());
		}

		[HttpPost]
		public ActionResult SearchHistory(SearchFormModelWithOffset model)
		{
			if (!ModelState.IsValid)
				return null;

			var query = this.DbContext.SearchResult
				.Where(x => x.SearchQuery.Query.Contains(model.Query));

			if (model.Offset.HasValue)
				query = query.Where(x => x.Id < model.Offset.Value);

			var historyResults = query
				.OrderByDescending(x => x.Id)
				.Take(20);

			return this.PartialView("SearchResults", historyResults.AsEnumerable());
		}
	}
}