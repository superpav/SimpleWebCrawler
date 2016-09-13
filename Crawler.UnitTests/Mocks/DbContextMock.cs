using System.Data.Entity;
using Crawler.Domain.Entities;

namespace Crawler.UnitTests.Mocks
{
	public class DbContextMock : ICrawlerContext
	{
		public DbSet<SearchQuery> SearchQuery { get; set; }
		public DbSet<SearchResult> SearchResult { get; set; }

		public DbContextMock()
		{
			this.SearchQuery = new DbSetMock<SearchQuery>();
			this.SearchResult = new DbSetMock<SearchResult>();
		}

		public int SaveChanges()
		{
			return 0;
		}
	}
}
