using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Crawler.Domain.Entities;
using Crawler.Framework.SearchProcessors;
using Crawler.Framework.SearchResultParsers;
using Crawler.Web.Framework.Mvc;
using Crawler.Web.ViewModels;
using NLog;

namespace Crawler.Web.Controllers
{
	public class RootController : CustomController
	{
		protected readonly ISearchProcessor SearchProcessor;

		protected Logger Logger = LogManager.GetCurrentClassLogger();

		public RootController(ISearchProcessor searchProcessor, ICrawlerContext dbContext) : base(dbContext)
		{
			this.SearchProcessor = searchProcessor;
		}

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
			if (!this.ModelState.IsValid)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var searchResult = await this.SearchProcessor.SearchAsync(model.Query);
			var searchResultParser = SearchResultParserFactory.CreateParser(searchResult.EngineType);
			var parsedResults = searchResultParser.Parse(searchResult.Result).ToList();

			if (parsedResults.Count == 0)
				return new EmptyResult();

			var searchQuery = new SearchQuery
			{
				Query = model.Query
			};

			foreach (var result in parsedResults)
			{
				searchQuery.SearchResult.Add(new SearchResult
				{
					Link = result.Url,
					Title = result.Title,
					Description = result.Desciption,
					SearchEngineType = searchResult.EngineType
				});
			}

			this.DbContext.SearchQuery.Add(searchQuery);
			this.DbContext.SaveChanges();

			return this.PartialView("SearchResults", searchQuery.SearchResult.AsEnumerable());
		}

		[HttpPost]
		public ActionResult SearchHistory(SearchFormModelWithOffset model)
		{
			if (!this.ModelState.IsValid)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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